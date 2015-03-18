using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HomeBudgetMVVM.Models;
using Microsoft.Practices.Prism.Commands;

namespace HomeBudgetMVVM.ViewModels
{
    public class ChartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private BudgetManager bm;

        public ChartViewModel()
        {
            bm = new BudgetManager();
            _chartExpensesByCategoryCommand = new DelegateCommand(ChartExpensesByCategory);
            _chartIncomeByCategoryCommand = new DelegateCommand(ChartIncomeByCategory);
            _chartAssetsByAccountCommand = new DelegateCommand(ChartAssetsByAccount);
            ChartIncomeByCategory();
            _chartValues = new ObservableCollection<DataPoint>();
        }

        #region Chart

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Properties
        private ObservableCollection<DataPoint> _chartValues;
        public ObservableCollection<DataPoint> ChartValues
        {
            get { return _chartValues;}
            set
            {
                _chartValues = value;
                RaisePropertyChanged("ChartValues");
            }
        }

        private String _chartTitle;
        public String ChartTitle
        {
            get { return _chartTitle; }
            set
            {
                _chartTitle = value;
                RaisePropertyChanged("ChartTitle");
            }
        }

        private String _chartSubTitle;
        public String ChartSubTitle
        {
            get { return _chartSubTitle; }
            set
            {
                _chartSubTitle = value;
                RaisePropertyChanged("ChartTitle");
            }
        }

        private object _selectedItem = null;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public class DataPoint
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }
        #endregion

        #region ICommands

        private ICommand _chartIncomeByCategoryCommand;
        public ICommand ChartIncomeByCategoryCommand
        {
            get { return _chartIncomeByCategoryCommand; }
        }

        private ICommand _chartExpensesByCategoryCommand;
        public ICommand ChartExpensesByCategoryCommand
        {
            get { return _chartExpensesByCategoryCommand; }
        }

        private ICommand _chartAssetsByAccountCommand;
        public ICommand ChartAssetsByAccountCommand
        {
            get { return _chartAssetsByAccountCommand; }
        }
        #endregion

        #region Commands
        private void ChartExpensesByCategory()
        {
            if (ChartValues == null) return;
            ChartValues.Clear();
            foreach (var c in bm.GetCategoryList())
            {
                ChartValues.Add(new DataPoint() {Name = c.CategoryName, Number = -bm.GetExpensesByCategory(c)});
            }
            SetChartTitles("Utgifter", "Totalt utgifter efter kategori");
        }

        private void ChartIncomeByCategory()
        {
            if (ChartValues == null) return;
            ChartValues.Clear();
            foreach (var c in bm.GetCategoryList())
            {
                ChartValues.Add(new DataPoint() {Name = c.CategoryName, Number = bm.GetIncomeByCategory(c)});
            }
            SetChartTitles("Inkomster", "Totalt inkomster efter kategori");
        }

        private void ChartAssetsByAccount()
        {
            if (ChartValues == null) return;
            ChartValues.Clear();
            foreach (var a in bm.GetAccountList())
            {
                ChartValues.Add(new DataPoint() { Name = a.AccountName, Number = a.Balance });
            }
            SetChartTitles("Tillgångar", "Totalt antal tillgångar per konto");
        }
        
        private void SwitchToPie(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            //view.Pie.Visibility = Visibility.Visible;
        }

        private void SwitchToStacked(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            //view.Stacked.Visibility = Visibility.Visible;
        }

        private void SwitchToBar(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            //view.Bar.Visibility = Visibility.Visible;
        }

        private void SwitchToRadial(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            //view.Radial.Visibility = Visibility.Visible;
        }

        private void CollapseAllCharts()
        {
            //view.Pie.Visibility = Visibility.Collapsed;
            //view.Stacked.Visibility = Visibility.Collapsed;
            //view.Bar.Visibility = Visibility.Collapsed;
            //view.Radial.Visibility = Visibility.Collapsed;
        }

        private void SetChartTitles(string title, string subtitle)
        {
            ChartTitle = title;
            ChartSubTitle = subtitle;
        }
        #endregion

        #endregion

    }
    
}
