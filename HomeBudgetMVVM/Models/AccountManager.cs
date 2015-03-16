using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using HomeBudgetMVVM.Views;

namespace HomeBudgetMVVM.Models
{
    class AccountManager
    {
        public List<Account> accountList;
        public List<Category> categoryList;
        public DateTime date;

        public AccountManager()
        {
            accountList = new List<Account>();
            categoryList = new List<Category>();
            date = DateTime.Now;
        }

        internal void AddAccount()
        {
            AddAccountWindow winAddAccount = new AddAccountWindow();

            if (winAddAccount.ShowDialog() == true)
            {
                accountList.Add(new Account(date)
                {
                    AccountName = winAddAccount.AccountName,
                    Number = winAddAccount.Number,
                    Balance = winAddAccount.Balance,
                    StartBalance = winAddAccount.Balance,
                    Bank = winAddAccount.Bank,
                    Comment = winAddAccount.Comment,
                });
            }
        }

        internal void SetDate(DateTime d)
        {
            date = d;
            foreach (Account a in accountList)
            {
                a.Date = d;
                a.UpdateBalance();
            }
        }

        internal void DeleteAccount(Account a)
        {
        }

    }
}
