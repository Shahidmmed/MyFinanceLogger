using MyFinanceLogger.Executors;
using MyFinanceLogger.Extensions;
using MyFinanceLogger.Models;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinanceLogger.Repositories
{
    public class SPRepository : ISPRepository
    {
        private readonly IStoredProcedureExecutor SPExecutor;

        public SPRepository(IStoredProcedureExecutor storedProcedureExecutor) => SPExecutor = storedProcedureExecutor;

        public async Task<string> CreateExpense(DateTime reqExpenseDate, double reqExpenseAmount, int reqExpenseCategoryId, string reqExpenseDescription)
        {

            string response = "unable to create expense";

            var spParams = new List<StoreProcedureParameter> {
                new StoreProcedureParameter {Name="reqExpenseDate", Type = NpgsqlDbType.Timestamp, Value = reqExpenseDate},
                new StoreProcedureParameter {Name="reqExpenseAmount", Type = NpgsqlDbType.Double, Value = reqExpenseAmount},
                new StoreProcedureParameter {Name="reqExpenseCategoryId", Type = NpgsqlDbType.Integer, Value = reqExpenseCategoryId},
                new StoreProcedureParameter {Name="reqExpenseDescription", Type = NpgsqlDbType.Varchar, Value = reqExpenseDescription},
            };

            await SPExecutor.ExecuteStoredProcedure("\"CreateExpense\"", spParams, (reader) => {
                try
                {
                    if (reader.Read())
                    {
                        response = reader.GetString(0);
                    }
                }
                catch (Exception e)
                {

                    throw;
                }            
            });

            return response;
        }

        public async Task<List<ExpenseCategoriesModel>> GetExpenseCategories()
        {
            List<ExpenseCategoriesModel> expenseCategories = new List<ExpenseCategoriesModel> { };

            await SPExecutor.ExecuteStoredProcedure("\"GetExpenseCategories\"", null ,(reader) => {
                while (reader.Read())
                {
                    try
                    {
                        expenseCategories.Add(new ExpenseCategoriesModel
                        {
                            ExpenseCategoryId = reader.Get<int>("ExpenseCategoryId"),
                            ExpenseCategoryName = reader.Get<string>("ExpenseCategory"),
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            });

            return expenseCategories;
        }

    }
}
