using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace HomeBudgetMVVM.Models
{
    public class Category
    {

        public Category()
        {
            Date = DateTime.Now;
        }

        public void AddExpense(double d)
        {
            CategoryExpenseAdded += d;
            UpdateCategoryBalance();
        }

        public void AddIncome(double d)
        {
            CategoryIncomeAdded += d;
            UpdateCategoryBalance();
        }

        private void UpdateCategoryBalance()
        {
            CategoryBalance = CategoryIncomeAdded + CategoryExpenseAdded;
        }

        public override string ToString()
        {
            return CategoryName;
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryComment { get; set; }
        public DateTime Date { get; set; }
        public double CategoryIncomeAdded { get; set; }
        public double CategoryExpenseAdded { get; set; }
        public double CategoryBalance { get; set; }
    }
}
