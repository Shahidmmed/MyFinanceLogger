using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinanceLogger.Models
{
    public class ExpenseModel
    {
        public DateTime ExpenseDate { get; set; }
        public double ExpenseAmount { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string ExpenseDescription { get; set; }
    }
}
