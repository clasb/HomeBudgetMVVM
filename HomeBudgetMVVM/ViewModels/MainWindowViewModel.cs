using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using HomeBudgetMVVM.Views;

namespace HomeBudgetMVVM.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<UserControl> Tabs {get;set;}
        public UserControl SelectedTab;

        public MainWindowViewModel()
        {
            Tabs = new ObservableCollection<UserControl> {new OverviewUserControl()};
            SelectedTab = Tabs[0];
        }
    }
}
