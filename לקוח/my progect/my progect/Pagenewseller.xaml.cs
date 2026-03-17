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
    /// Interaction logic for Pagenewseller.xaml
    /// </summary>
    public partial class Pagenewseller : Page
    {
        Service1Client sc;
        Seller c;
        Costumer co;
        string status;
        public Pagenewseller(Seller c, string status)
        {
            InitializeComponent();
            sc = new Service1Client();
            DataContext = c;
            this.c = c;
            Global.Seller = c;
            if(Global.Seller!=null)
            {
             this.DataContext = c;
            }
            else
            {
                co = Global.Costumer;
                this.DataContext = co;
            }
            
            this.status = status;
            cmbcity.ItemsSource = sc.SelectAllcity();
            if (status == "new")
            {
                btncontinue.Visibility = Visibility;
            }
            else
            {
                btnupdate.Visibility = Visibility;
            }
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (status == "new")
            { 
              Global.Service1.Insertseller(c);  
            Global.Seller = c;
             string   statuse = "new";
             Business   business = new Business();
                
                this.NavigationService.Navigate(new Pagenewbusiness(statuse, business));
            }
            else
            {
                Global.Service1.Updateseller(c);
                this.NavigationService.GoBack();
                Global.Seller = c;
            }   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Global.Service1.Updateseller(c);
            this.NavigationService.Navigate(new personal());
            Global.Seller = c;
        }
    }
}
