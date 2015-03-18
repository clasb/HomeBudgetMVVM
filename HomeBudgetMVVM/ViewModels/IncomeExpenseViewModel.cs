using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HomeBudgetMVVM.Models;
using Microsoft.Practices.Prism.Commands;

namespace HomeBudgetMVVM.ViewModels
{
    public class IncomeExpenseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BudgetManager bm;

        public IncomeExpenseViewModel()
        {
            bm = new BudgetManager();
            Accounts = bm.GetAccountList();
            Categories = bm.GetCategoryList();
            AccountEvents = bm.GetAccountEventList();
            _newExpenseCommand = new DelegateCommand(AddExpense);
            _newIncomeCommand = new DelegateCommand(AddIncome);
            _newCategoryCommand = new DelegateCommand(NewCategory);
        }

        #region Command-methods
        private void AddExpense()
        {
            bm.NewExpense();
            AccountEvents = App.Database.AccountEvents().ToList();
        }

        private void AddIncome()
        {
            bm.NewIncome();
            AccountEvents = App.Database.AccountEvents().ToList();
        }

        private void NewCategory()
        {
            bm.NewCategory();
            Categories = App.Database.Categories().ToList();
        }
        #endregion

        #region ICommands
        public ICommand NewExpenseCommand
        {
            get { return _newExpenseCommand; }
        }
        private ICommand _newExpenseCommand;

        public ICommand NewIncomeCommand
        {
            get { return _newIncomeCommand; }
        }
        private ICommand _newIncomeCommand;

        public ICommand NewCategoryCommand
        {
            get { return _newCategoryCommand; }
        }
        private ICommand _newCategoryCommand;
        #endregion

        #region Properties

        private Category _selectedCategory;
        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (value == null) return;
                _selectedCategory = value;
                AccountEvents = bm.GetAccountEventListByCategory(value);
                SelectedCategoryId = value.ID;
                RaisePropertyChanged("SelectedAccount");
            }
        }

        private int _selectedCategoryId;
        public int SelectedCategoryId
        {
            get { return _selectedCategoryId; }
            set
            {
                _selectedCategoryId = value;
                RaisePropertyChanged("SelectedAccountId");
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
