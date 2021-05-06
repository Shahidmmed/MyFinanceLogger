using MyFinanceLogger.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MyFinanceLogger.Executors
{
    public interface IStoredProcedureExecutor
    {
        Task ExecuteStoredProcedure(string storeProcedureName, List<StoreProcedureParameter> parameters, Action<IDataReader> callback = null);
    }
}