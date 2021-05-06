using Microsoft.AspNetCore.Mvc;
using MyFinanceLogger.Models;
using MyFinanceLogger.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinanceLogger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly ISPRepository storedProcedures;
        public ValuesController(ISPRepository storedProcedure)
        {
            this.storedProcedures = storedProcedure;
        }

        [HttpPost("[action]")]
        public async Task<ApiResponse> CreateExpenses([FromBody] ExpenseModel expense)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(expense.ExpenseDescription)) return new ApiResponse { IsSuccessful = false, Message = "Expense Description Required." };
                if (expense.ExpenseCategoryId == 0) return new ApiResponse { IsSuccessful = false, Message = "Expense Category is required." };
                if (expense.ExpenseDate == null) return new ApiResponse { IsSuccessful = false, Message = "Expense Date is required." };


                var expenseResult = await storedProcedures.CreateExpense(expense.ExpenseDate, expense.ExpenseAmount, expense.ExpenseCategoryId, expense.ExpenseDescription);

                if (string.IsNullOrWhiteSpace(expenseResult))
                {
                    return new ApiResponse { Message = "Expense successfully created", IsSuccessful = true };
                }


                return new ApiResponse { Message = expenseResult, IsSuccessful = false };

            }
            catch (Exception e)
            {
                return new ApiResponse { Message = e.Message, IsSuccessful = false };
            }
        }

        [HttpGet("[action]")]
        public async Task<ApiResponse> GetExpenseCategories()
        {
            try
            {
                var expenseCategories = await storedProcedures.GetExpenseCategories();
                if (expenseCategories != null || !expenseCategories.Any())
                {
                    return new ApiResponse { Data = expenseCategories, IsSuccessful = true };
                }

                return new ApiResponse { Message = "Unable to load expense categories", IsSuccessful = false };
            }
            catch (Exception e)
            {
                return new ApiResponse { Message = e.Message, IsSuccessful = false };
            }
        }

    }
}
