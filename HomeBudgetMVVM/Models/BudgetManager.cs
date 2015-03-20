using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBudgetMVVM.Models
{
    public class BudgetManager
    {
        private AccountManager am;

        public BudgetManager()
        {
            am = new AccountManager();
        }

        public List<Account> GetAccountList()
        {
            return App.Database.Accounts().ToList();
        }

        public List<AccountEvent> GetAccountEventList()
        {
            return App.Database.AccountEvents().ToList();
        }

        public List<AccountEvent> GetAccountEventListByAccount(Account a)
        {
            return am.GetAccountEventListByAccount(a);
        }

        public List<AccountEvent> GetAccountEventListByCategory(Category c)
        {
            return am.GetAccountEventListByCategory(c);
        }

        public List<AccountEvent> GetPastAccountEventList()
        {
            return am.GetPastAccountEvents();
        }

        public List<AccountEvent> GetComingAccountEventList()
        {
            return am.GetComingAccountEvents();
        }

        public List<AccountEvent> GetPastAccountEventListByCategory(Category c)
        {
            return am.GetPastAccountEventsByCategory(c);
        }
        public List<AccountEvent> GetComingAccountEventListByCategory(Category c)
        {
            return am.GetComingAccountEventsByCategory(c);
        }

        public List<Category> GetCategoryList()
        {
            return App.Database.Categories().ToList();
        }

        public double GetExpensesByCategory(Category c)
        {
            return am.GetExpensesByCategory(c);
        }

        public double GetIncomeByCategory(Category c)
        {
            return am.GetIncomeByCategory(c);
        }

        internal void AddAccount()
        {
            am.AddAccount();
        }

        internal void ShareAccount(Account a)
        {
            //am.AddAccountEvent(a);
        }

        internal void DeleteAccount(Account i)
        {
            am.DeleteAccount(i);
        }

        internal void NewIncome()
        {
            am.AddAccountEvent("Income");
        }

        internal void NewExpense()
        {
            am.AddAccountEvent("Expense");
        }

        internal DateTime GetDate()
        {
            return am.date;
        }

        internal void SetDate(DateTime d)
        {
            am.SetDate(d);
        }

        internal void Save()
        {
            //am.Save();
        }

        internal void Open()
        {
            //am.Open();
        }

        internal void NewCategory()
        {
            am.AddCategory();
        }
    }
}
