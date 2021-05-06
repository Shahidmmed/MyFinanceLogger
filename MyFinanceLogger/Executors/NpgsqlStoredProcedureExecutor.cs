using MyFinanceLogger.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceLogger.Executors
{
    public class NpgsqlStoredProcedureExecutor : IStoredProcedureExecutor
    {
        private string connectionString;
        public NpgsqlStoredProcedureExecutor(string connectionString) => this.connectionString = connectionString;
        private NpgsqlConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }


        private async Task<NpgsqlConnection> PrepConnectionAsnyc(StringBuilder duration)
        {
            var start = DateTime.Now;
            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            duration.Append($"\nPG_DB Connection open duration {(DateTime.Now - start).TotalSeconds}");
            return connection;
        }

        public async Task ExecuteStoredProcedure(string storeProcedureName, List<StoreProcedureParameter> parameters, Action<IDataReader> callback = null)
        {
            int index = 0;
            StringBuilder duration = new StringBuilder();
            using (NpgsqlConnection connection = await PrepConnectionAsnyc(duration))
            {
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = storeProcedureName;
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null && parameters.Any())
                        {
                            foreach (StoreProcedureParameter parameter in parameters)
                            {
                                command.Parameters.Add(new NpgsqlParameter(parameter.Name, parameter.Type));
                                command.Parameters[index++].Value = parameter.Value;
                            }
                        }

                        if (callback != null)
                            using (NpgsqlDataReader reader = await command.ExecuteReaderAsync()) callback.Invoke(reader);
                        else
                            await command.ExecuteScalarAsync();

                        CloseConnection(connection, command);
                    }
                }
                catch (Exception)
                {
                    CloseConnectionOnly(connection);
                    throw;
                }

            }
        }



        private void CloseConnection(NpgsqlConnection connection, NpgsqlCommand command)
        {
            command.Dispose();
            connection.Dispose();
            connection.Close();
        }



        private void CloseConnectionOnly(NpgsqlConnection connection)
        {
            connection.Dispose();
            connection.Close();
        }
    }
}
