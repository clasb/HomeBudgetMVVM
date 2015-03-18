using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using HomeBudgetMVVM.Models;
using HomeBudgetMVVM.Views;
using Microsoft.Practices.Prism.Commands;

namespace HomeBudgetMVVM.ViewModels
{
    public class AccountsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BudgetManager bm;

        public AccountsViewModel()
        {
            bm = new BudgetManager();
            Accounts = bm.GetAccountList();
            Categories = bm.GetCategoryList();
            AccountEvents = bm.GetAccountEventList();
            _newAccountCommand = new DelegateCommand(AddAccount);
            _deleteAccountCommand = new DelegateCommand(DeleteAccount);
        }

        #region Command-methods
        private void AddAccount()
        {
            bm.AddAccount();
            Accounts = bm.GetAccountList();
        }

        private void DeleteAccount()
        {
            bm.DeleteAccount(SelectedAccount);
            Accounts = bm.GetAccountList();
        }
        #endregion

        #region ICommands
        public ICommand NewAccountCommand
        {
            get { return _newAccountCommand; }
        }
        private ICommand _newAccountCommand;

        public ICommand DeleteAccountCommand
        {
            get { return _deleteAccountCommand; }
        }
        private ICommand _deleteAccountCommand;
        #endregion

        #region Properties

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value; 
                AccountEvents = bm.GetAccountEventListByAccount(SelectedAccount);
                SelectedAccountId = value.ID;
                RaisePropertyChanged("SelectedAccount");
            }
        }

        private int _selectedAccountId;
        public int SelectedAccountId
        {
            get { return _selectedAccountId; }
            set
            {
                _selectedAccountId = value;
                RaisePropertyChanged("SelectedAccountId");
            }
        }

        private Account _selectedEvent;
        public Account SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                RaisePropertyChanged("SelectedEvent");
            }
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
        #endregion

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
    }
}
