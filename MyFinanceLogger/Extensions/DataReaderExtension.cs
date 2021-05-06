using System;
using System.Data;

namespace MyFinanceLogger.Extensions
{
    public static class DataReaderExtension
    {
        public static bool IsDBNull(this IDataReader dataReader, string columnName)
        {
            return dataReader[columnName] == DBNull.Value;
        }
        public static T Get<T>(this IDataReader dataReader, string columnName)
        {
            return IsDBNull(dataReader, columnName) ? default(T) : (T)dataReader[columnName];
        }
    }
}
