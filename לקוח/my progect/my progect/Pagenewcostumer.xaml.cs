using my_progect.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for Pagenewcostumer.xaml
    /// </summary>
    public partial class Pagenewcostumer : Page
    {
        Service1Client sc;
       Costumer c;
        string status;
        public Pagenewcostumer(string status , Costumer c)
        {
            InitializeComponent();
            sc = new Service1Client();
            this.c = c;
            this.DataContext = c;
            this.status = status;
            cmbcity.ItemsSource = sc.SelectAllcity();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (status == "new")
            {
                Global.Service1.Insertcostumer(c);
                Global.Costumer = c;
                Global.MainWindow.frm.NavigationService.Navigate(new PageMainCostumer());
                Global.MainWindow.myMenu.Visibility = Visibility.Visible;
                Global.MainWindow.chat.Visibility = Visibility.Collapsed;
                Global.MainWindow.business.Visibility = Visibility.Collapsed;
                Global.MainWindow.chatcos.Visibility = Visibility.Visible;
                
                Global.connection.Close();

            }
            else
            {
                Global.Service1.Updatecostumer (c);
            }
           
        }

        private void cmbcity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
