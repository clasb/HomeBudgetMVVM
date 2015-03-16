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
using HomeBudgetMVVM.Models;

namespace HomeBudgetMVVM.Views
{
    /// <summary>
    /// Interaction logic for AddIncomeExpenseWindow.xaml
    /// </summary>
    public partial class AddIncomeExpenseWindow : Window
    {
        private List<Account> accountList;
        private List<Category> categoryList;

        public AddIncomeExpenseWindow(List<Account> aL, List<Category> cL)
        {
            InitializeComponent();
            this.accountList = aL;
            this.categoryList = cL;
            foreach (Account a in accountList)
                AccountListBox.Items.Add(a);
            foreach (Category c in categoryList)
                CategoryListBox.Items.Add(c);
        }

        public static readonly DependencyProperty EventAccountProperty = DependencyProperty.Register("EventAccount", typeof(Account), typeof(AddIncomeExpenseWindow), new UIPropertyMetadata(new Account(DateTime.Now)));
        public Account EventAccount
        {
            get { return (Account)GetValue(EventAccountProperty); }
            set { SetValue(EventAccountProperty, value); }
        }

        public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(AddIncomeExpenseWindow), new UIPropertyMetadata(String.Empty));
        public string EventType
        {
            get { return (string)GetValue(EventTypeProperty); }
            set { SetValue(EventTypeProperty, value); }
        }

        public static readonly DependencyProperty EventCategoryProperty = DependencyProperty.Register("EventCategory", typeof(Category), typeof(AddIncomeExpenseWindow), new UIPropertyMetadata(null));
        public Category EventCategory
        {
            get { return (Category)GetValue(EventCategoryProperty); }
            set { SetValue(EventCategoryProperty, value); }
        }

        public static readonly DependencyProperty EventBalanceProperty = DependencyProperty.Register("EventBalance", typeof(double), typeof(AddIncomeExpenseWindow), new UIPropertyMetadata(null));
        public double EventBalance
        {
            get { return (double)GetValue(EventBalanceProperty); }
            set { SetValue(EventBalanceProperty, value); }
        }

        public static readonly DependencyProperty EventCommentProperty = DependencyProperty.Register("EventComment", typeof(string), typeof(AddIncomeExpenseWindow), new UIPropertyMetadata(String.Empty));
        public string EventComment
        {
            get { return (string)GetValue(EventCommentProperty); }
            set { SetValue(EventCommentProperty, value); }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }


    }
}
