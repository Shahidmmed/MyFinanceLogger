using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyFinanceLogger.Models;

namespace MyFinanceLogger.Repositories
{
    public interface ISPRepository
    {
        Task<List<ExpenseCategoriesModel>> GetExpenseCategories();
        Task<string> CreateExpense(DateTime reqExpenseDate, double reqExpenseAmount, int reqExpenseCategoryId, string reqExpenseDescription);
    }
}