using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp9.TRDataSetTableAdapters;

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public Page3()
        {
            InitializeComponent();
            CustomersDataGrid.ItemsSource = orders.GetData();
            SS.ItemsSource = orders.GetData();
            SS.DisplayMemberPath = "Customer_ID";
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomersDataGrid.ItemsSource = orders.GetDataBy(SearchTxt.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomersDataGrid.ItemsSource = orders.GetData();
        }

        private void SS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SS.SelectedItem != null)
            {

                var id = (int)(SS.SelectedItem as DataRowView).Row[0];
                CustomersDataGrid.ItemsSource = orders.Prf(id);
            }
        }
    }
}
