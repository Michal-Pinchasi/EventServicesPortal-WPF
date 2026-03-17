using my_progect.ServiceReference1;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace my_progect
{
    /// <summary>
    /// Interaction logic for PageBusinessSeller.xaml
    /// </summary>
    public partial class PageBusinessSeller : Page
    {
        Business business;
        string statuse;
        public PageBusinessSeller()
        {
            InitializeComponent();
            lst3.ItemsSource = Global.buslist;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            statuse = "old";
            business = new Business();
            this.NavigationService.Navigate(new Pagenewbusiness(statuse, business));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            statuse = "update";
            business = new Business();
            business = ((Business)lst3.SelectedItem);
            this.NavigationService.Navigate(new Pagenewbusiness(statuse, business));
        }
    }
}
