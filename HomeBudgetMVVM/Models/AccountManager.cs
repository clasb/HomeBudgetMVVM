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
            App.Database.DeleteAccount(a.ID);
        }


        internal void AddAccountEvent(String s)
        {
            AddIncomeExpenseWindow winAIE = new AddIncomeExpenseWindow(App.Database.Accounts().ToList(), App.Database.Categories().ToList());

            if (winAIE.ShowDialog() != true) return;
            double balance;
            if (s.Equals("Income"))
            {
                balance = winAIE.EventBalance;
            }
            else
            {
                balance = -winAIE.EventBalance;
            }

            AddAccountEvent(new AccountEvent()
            {
                EventType = s,
                AccountID = winAIE.EventAccount.ID,
                CategoryID = winAIE.EventCategory.ID,
                EventBalance = balance,
                EventComment = winAIE.EventComment,
                Date = winAIE.Date
            });
        }

        internal void AddAccountEvent(AccountEvent a)
        {
            App.Database.SaveAccountEvent(a);
        }

        internal void AddCategory()
        {
            AddCategoryWindow winAC = new AddCategoryWindow();

            if (winAC.ShowDialog() == true)
            {
                App.Database.SaveCategory(new Category()
                {
                    CategoryName = winAC.CategoryName,
                    CategoryComment = winAC.CategoryComment,
                });
            }
        }

        public List<AccountEvent> GetAccountEventListByAccount(Account a)
        {
            {
                try
                {
                    return App.Database.GetAccountEventsByAccount(a.ID).ToList();
                }
                catch (NullReferenceException)
                {
                    return new List<AccountEvent>();
                }
            }
        }

        public List<AccountEvent> GetAccountEventListByCategory(Category c)
        {
            {
                try
                {
                    return App.Database.GetAccountEventsByCategory(c.ID).ToList();
                }
                catch (NullReferenceException)
                {
                    return new List<AccountEvent>();
                }
            }
        }

        public List<AccountEvent> GetPastAccountEvents()
        {
            try
            {
                List<AccountEvent> tempList = new List<AccountEvent>();
                foreach (var a in App.Database.AccountEvents().ToList())
                {
                    if (DateTime.Compare(a.Date, DateTime.Now) <= 0)
                        tempList.Add(a);
                }
                return tempList;
            }
            catch (Exception)
            {
                return new List<AccountEvent>();
            }
        }

        public List<AccountEvent> GetComingAccountEvents()
        {
            try
            {
                List<AccountEvent> tempList = new List<AccountEvent>();
                foreach (var a in App.Database.AccountEvents().ToList())
                {
                    if (DateTime.Compare(a.Date, DateTime.Now) > 0)
                        tempList.Add(a);
                }
                return tempList;
                //return App.Database.GetComingAccountEvents().ToList();
            }
            catch (Exception)
            {
                return new List<AccountEvent>();
            }
        }

        public List<AccountEvent> GetPastAccountEventsByCategory(Category c)
        {
            try
            {
                List<AccountEvent> tempList = new List<AccountEvent>();
                foreach (var a in App.Database.GetAccountEventsByCategory(c.ID).ToList())
                {
                    if (DateTime.Compare(a.Date, DateTime.Now) <= 0)
                        tempList.Add(a);
                }
                return tempList;
            }
            catch (Exception)
            {
                return new List<AccountEvent>();
            }
        }

        public List<AccountEvent> GetComingAccountEventsByCategory(Category c)
        {
            try
            {
                List<AccountEvent> tempList = new List<AccountEvent>();
                foreach (var a in App.Database.GetAccountEventsByCategory(c.ID).ToList())
                {
                    if (DateTime.Compare(a.Date, DateTime.Now) > 0)
                        tempList.Add(a);
                }
                return tempList;
            }
            catch (Exception)
            {
                return new List<AccountEvent>();
            }
        }

        public double GetExpensesByCategory(Category c)
        {
            double result = 0;
            var temp = App.Database.GetAccountEventsByCategory(c.ID).ToList();
            if (temp != null)
            {
                result += temp.Where(cat => cat.EventBalance < 0).Sum(cat => cat.EventBalance);
            }
            return result;
        }

        public double GetIncomeByCategory(Category c)
        {
            double result = 0;
            var temp = App.Database.GetAccountEventsByCategory(c.ID).ToList();
            if (temp != null)
            {
                result += temp.Where(cat => cat.EventBalance > 0).Sum(cat => cat.EventBalance);
            }
            return result;
        }
    }
}
