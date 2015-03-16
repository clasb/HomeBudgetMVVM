using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HomeBudgetMVVM.Database;
using SQLite;

namespace HomeBudgetMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SQLiteConnection _dbConnection;
        private static BudgetDatabase _database;

        public App()
        {
            _dbConnection = new SQLiteConnection("DataSource=Budget.sqlite;Version=3;New=True");
            _database = new BudgetDatabase(_dbConnection);
        }

        public static BudgetDatabase Database
        {
            get { return _database; }
        }
    }
}
