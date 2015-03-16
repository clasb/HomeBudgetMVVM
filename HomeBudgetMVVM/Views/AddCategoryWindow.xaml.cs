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
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CategoryNameProperty = DependencyProperty.Register("CategoryName", typeof(string), typeof(AddCategoryWindow), new UIPropertyMetadata(String.Empty));
        public string CategoryName
        {
            get { return (string)GetValue(CategoryNameProperty); }
            set { SetValue(CategoryNameProperty, value); }
        }

        public static readonly DependencyProperty CategoryCommentProperty = DependencyProperty.Register("CategoryComment", typeof(string), typeof(AddCategoryWindow), new UIPropertyMetadata(String.Empty));
        public string CategoryComment
        {
            get { return (string)GetValue(CategoryCommentProperty); }
            set { SetValue(CategoryCommentProperty, value); }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
