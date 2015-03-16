using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeBudgetMVVM.Views
{
    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        public AddAccountWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AccountNameProperty = DependencyProperty.Register("AccountName", typeof(string), typeof(AddAccountWindow), new UIPropertyMetadata(String.Empty));
        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register("Number", typeof(string), typeof(AddAccountWindow), new UIPropertyMetadata(String.Empty));
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty BalanceProperty = DependencyProperty.Register("Balance", typeof(double), typeof(AddAccountWindow), new UIPropertyMetadata(null));
        public double Balance
        {
            get { return (double)GetValue(BalanceProperty); }
            set { SetValue(BalanceProperty, value); }
        }

        public static readonly DependencyProperty BankProperty = DependencyProperty.Register("Bank", typeof(string), typeof(AddAccountWindow), new UIPropertyMetadata(String.Empty));
        public string Bank
        {
            get { return (string)GetValue(BankProperty); }
            set { SetValue(BankProperty, value); }
        }

        public static readonly DependencyProperty CommentProperty = DependencyProperty.Register("Comment", typeof(string), typeof(AddAccountWindow), new UIPropertyMetadata(String.Empty));
        public string Comment
        {
            get { return (string)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
