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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        BurgersTableAdapter burger = new BurgersTableAdapter();
        

        public Page1()
        {
            InitializeComponent();
            BurgerDgr.ItemsSource = burger.GetData();
            SS.ItemsSource = burger.GetData();
            SS.DisplayMemberPath = "BurgerName";
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BurgerDgr.ItemsSource = burger.SearchByName(SearchTxt.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BurgerDgr.ItemsSource = burger.GetData();
        }

        private void SS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (SS.SelectedItem != null) 
            {

                var id = (int)(SS.SelectedItem as DataRowView).Row[0];
                BurgerDgr.ItemsSource = burger.Pr(id);
            }             
            
        }
    }

    
}
