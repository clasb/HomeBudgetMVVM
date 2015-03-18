using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using HomeBudgetMVVM.Models;
using SQLite.Net;

namespace HomeBudgetMVVM.Database
{
    public class BudgetDatabase
    {
        private static object locker = new object();
        private SQLiteConnection database;

        public BudgetDatabase(SQLiteConnection conn)
        {
            database = conn;
            //Createtables here etc
            database.CreateTable<Account>();
            database.CreateTable<AccountEvent>();
            database.CreateTable<Category>();
        }

        //Database stuff you want it to do here

        #region Database Account handling
        public IEnumerable<Account> Accounts()
        {
            lock (locker)
            {
                return (from i in database.Table<Account>() select i).ToList();
            }
        }

        public int SaveAccount(Account account)
        {
            lock (locker)
            {
                if (account.ID != 0)
                {
                    database.Update(account);
                    return account.ID;
                }
                else
                {
                    return database.Insert(account);
                }
            }
        }

        public Account GetAccount(int id)
        {
            lock (locker)
            {
                return database.Table<Account>().FirstOrDefault(account => account.ID == id);
            }
        }

        public int DeleteAccount(int id)
        {
            lock (locker)
            {
                return database.Delete<Account>(id);
            }
        }
        #endregion

        #region Database AccountEvent handling
        public IEnumerable<AccountEvent> AccountEvents()
        {
            lock (locker)
            {
                return (from i in database.Table<AccountEvent>() select i).ToList();
            }
        }

        public int SaveAccountEvent(AccountEvent accountEvent)
        {
            lock (locker)
            {
                if (accountEvent.ID != 0)
                {
                    database.Update(accountEvent);
                    return accountEvent.ID;
                }
                else
                {
                    return database.Insert(accountEvent);
                }
            }
        }

        public AccountEvent GetAccountEvent(int id)
        {
            lock (locker)
            {
                return database.Table<AccountEvent>().FirstOrDefault(accountEvent => accountEvent.ID == id);
            }
        }

        public IEnumerable<AccountEvent> GetAccountEventsByAccount(int id)
        {
            lock (locker)
            {
                var eventList = database.Query<AccountEvent>("SELECT * FROM AccountEvent WHERE AccountID = ?", id);
                return eventList;
            }
        }

        public IEnumerable<AccountEvent> GetAccountEventsByCategory(int id)
        {
            lock (locker)
            {
                var eventList = database.Query<AccountEvent>("SELECT * FROM AccountEvent WHERE CategoryID = ?", id);
                return eventList;
            }
        }

        public int DeleteAccountEvent(int id)
        {
            lock (locker)
            {
                return database.Delete<AccountEvent>(id);
            }
        }
        #endregion

        #region Database Category handling
        public IEnumerable<Category> Categories()
        {
            lock (locker)
            {
                return (from i in database.Table<Category>() select i).ToList();
            }
        }

        public int SaveCategory(Category category)
        {
            lock (locker)
            {
                if (category.ID != 0)
                {
                    database.Update(category);
                    return category.ID;
                }
                else
                {
                    return database.Insert(category);
                }
            }
        }

        public Category GetCategory(int id)
        {
            lock (locker)
            {
                return database.Table<Category>().FirstOrDefault(category => category.ID == id);
            }
        }

        public int Category(int id)
        {
            lock (locker)
            {
                return database.Delete<Category>(id);
            }
        }
        #endregion
    }
}
