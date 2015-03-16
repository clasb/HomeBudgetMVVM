using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HomeBudgetMVVM.Models;

namespace HomeBudgetMVVM.ViewModels
{
    public class ChartViewModel
    { 

        /*
        #region Chart

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        
        public static readonly DependencyProperty ChartValuesProperty = DependencyProperty.Register("ChartValues", typeof(ObservableCollection<DataPoint>), typeof(MainWindow), new UIPropertyMetadata(null));
        public ObservableCollection<DataPoint> ChartValues
        {
            get { return (ObservableCollection<DataPoint>)GetValue(ChartValuesProperty); }
            set { SetValue(ChartValuesProperty, value); }
        }

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

        public class DataPoint
        {
            public string Name { get; set; }
            public double Number { get; set; }
        }

        private void ChartExpensesByCategory(object sender, RoutedEventArgs e)
        {
            ChartValues.Clear();
            foreach (Category c in bm.GetCategoryList())
            {
                double temp;
                temp = c.CategoryExpenseAdded;
                if (temp < 0)
                {
                    temp = -temp;
                    ChartValues.Add(new DataPoint() { Name = c.CategoryName, Number = temp });
                }
            }
            SetChartTitles("Utgifter", "Totalt utgifter efter kategori");
        }

        private void ChartIncomeByCategory(object sender, RoutedEventArgs e)
        {
            ChartValues.Clear();
            foreach (Category c in bm.GetCategoryList())
            {
                if (c.CategoryIncomeAdded > 0)
                    ChartValues.Add(new DataPoint() { Name = c.CategoryName, Number = c.CategoryIncomeAdded });
            }
            SetChartTitles("Inkomster", "Totalt inkomster efter kategori");
        }

        private void ChartAssetsByAccount(object sender, RoutedEventArgs e)
        {
            ChartValues.Clear();
            foreach (Account a in bm.GetAccountList())
            {
                ChartValues.Add(new DataPoint() { Name = a.AccountName, Number = a.Balance });
            }
            SetChartTitles("Tillgångar", "Totalt antal tillgångar per konto");
        }

        private void SwitchToPie(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            view.Pie.Visibility = Visibility.Visible;
        }

        private void SwitchToStacked(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            view.Stacked.Visibility = Visibility.Visible;
        }

        private void SwitchToBar(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            view.Bar.Visibility = Visibility.Visible;
        }

        private void SwitchToRadial(object sender, RoutedEventArgs e)
        {
            CollapseAllCharts();
            view.Radial.Visibility = Visibility.Visible;
        }

        private void CollapseAllCharts()
        {
            view.Pie.Visibility = Visibility.Collapsed;
            view.Stacked.Visibility = Visibility.Collapsed;
            view.Bar.Visibility = Visibility.Collapsed;
            view.Radial.Visibility = Visibility.Collapsed;
        }

        private void SetChartTitles(string title, string subtitle)
        {
            //ChartTitle = title;
            view.Pie.ChartSubTitle = subtitle;
            view.Bar.ChartTitle = title;
            view.Bar.ChartSubTitle = subtitle;
            view.Stacked.ChartTitle = title;
            view.Stacked.ChartSubTitle = subtitle;
            view.Radial.ChartTitle = title;
            view.Radial.ChartSubTitle = subtitle;
        }

        #endregion
        */
    }
    
}
