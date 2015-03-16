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
            return am.accountList;
        }

        public List<AccountEvent> GetAccountEventList(Account a)
        {
            return new List<AccountEvent>();
        }

        public List<Category> GetCategoryList()
        {
            return am.categoryList;
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
            //am.AddAccountEvent("Income");
        }

        internal void NewExpense()
        {
            //am.AddAccountEvent("Expense");
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
            //am.AddCategory();
        }
    }
}
