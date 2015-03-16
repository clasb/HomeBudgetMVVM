using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using HomeBudgetMVVM.Models;
using SQLite;

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
        public IEnumerable<Account> Accounts()
        {
            lock (locker)
            {
                return (from i in database.Table<Account>() select i).ToList();
            }
        }

        public int NewAccount(Account account)
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
    }
}
