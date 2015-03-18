using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HomeBudgetMVVM.Database;
using SQLite.Net;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Win32;

namespace HomeBudgetMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static SQLiteConnection _dbConnection;
        private static BudgetDatabase _database;
        private static String DATABASE_NAME = "HomeBudget2.sqlite";

        public App()
        {

            _dbConnection = new SQLiteConnection(new SQLitePlatformWin32(), DATABASE_NAME);
            _database = new BudgetDatabase(_dbConnection);
        }

        public static BudgetDatabase Database
        {
            get { return _database; }
        }
    }
}
