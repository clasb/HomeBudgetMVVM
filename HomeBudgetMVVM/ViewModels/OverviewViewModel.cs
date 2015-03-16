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
        private OverviewUserControl view;
        private BudgetManager bm;

        public string Header
        {
            get { return "Overview"; }
        }
    }
}
