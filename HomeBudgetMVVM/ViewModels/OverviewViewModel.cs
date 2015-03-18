using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using De.TorstenMandelkow.MetroChart;
using HomeBudgetMVVM.Models;
using HomeBudgetMVVM.Views;

namespace HomeBudgetMVVM.ViewModels
{
    public class OverviewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public OverviewViewModel()
        {
            Accounts = App.Database.Accounts().ToList();
            Categories = App.Database.Categories().ToList();
            AccountEvents = App.Database.AccountEvents().ToList();
        }

        public string Header
        {
            get { return "Overview"; }
        }

        private List<Account> _accounts;

        public List<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                RaisePropertyChanged("Accounts");
            }
        }

        private List<Category> _categories;

        public List<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                RaisePropertyChanged("Categories");
            }
        }

        private List<AccountEvent> _accountEvents;

        public List<AccountEvent> AccountEvents
        {
            get { return _accountEvents; }
            set
            {
                _accountEvents = value;
                RaisePropertyChanged("AccountEvents");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
