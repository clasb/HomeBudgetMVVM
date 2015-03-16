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
        public DateTime date;

        public AccountManager()
        {
            date = DateTime.Now;
        }

        internal void AddAccount()
        {
            AddAccountWindow winAddAccount = new AddAccountWindow();

            if (winAddAccount.ShowDialog() == true)
            {
                App.Database.SaveAccount(new Account(date)
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
            foreach (Account a in App.Database.Accounts().ToList())
            {
                a.Date = d;
                a.UpdateBalance();
            }
        }

        internal void DeleteAccount(Account a)
        {
        }


        internal void AddAccountEvent(String s)
        {
            AddIncomeExpenseWindow winAIE = new AddIncomeExpenseWindow(App.Database.Accounts().ToList(), App.Database.Categories().ToList());

            if (winAIE.ShowDialog() == true)
            {
                double balance;
                if (s.Equals("Income"))
                {
                    balance = winAIE.EventBalance;
                    Category tempCategory = App.Database.GetCategory(winAIE.EventCategory.ID);
                    tempCategory.AddIncome(balance);
                    App.Database.SaveCategory(tempCategory);
                }
                else
                {
                    balance = -winAIE.EventBalance;
                    Category tempCategory = App.Database.GetCategory(winAIE.EventCategory.ID);
                    tempCategory.AddIncome(balance);
                    App.Database.SaveCategory(tempCategory);
                }

                AddAccountEvent(new AccountEvent()
                {
                    EventType = s,
                    AccountID = winAIE.EventAccount.ID,
                    EventBalance = balance,
                    EventComment = winAIE.EventComment,
                    Date = this.date
                });
            }
        }

        internal void AddAccountEvent(AccountEvent a)
        {
            App.Database.SaveAccountEvent(a);
        }
    }
}
