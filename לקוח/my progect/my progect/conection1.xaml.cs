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
    /// Interaction logic for conection1.xaml
    /// </summary>
    public partial class conection1 : Page
    {
        public conection1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {   Costumer costumer = new Costumer();
            string statuse1 = "new";
            this.NavigationService.Navigate(new Pagenewcostumer(statuse1 ,costumer));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Seller c = new Seller();
            string statuse = "new";
            this.NavigationService.Navigate(new Pagenewseller( c,statuse));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (fonsel.Text != "" /*|| codsel.Text!=null*/) 
            { 
            Global.Seller = Global.Service1.selectbyphoneseller(fonsel.Text);
               if(Global.Seller != null)
               {
                if(Global.Seller.Code== codsel.Text)
                {
                    Global.MainWindow.frm.NavigationService.Navigate(new PageMainSeller());
                    Global.MainWindow.myMenu.Visibility = Visibility.Visible;
                    Global.MainWindow.chatcos.Visibility = Visibility.Collapsed;
                    Global.MainWindow.chat.Visibility = Visibility.Visible;
                    Global.MainWindow.business.Visibility = Visibility.Visible;

                    List<Business> buslist1 = Global.Service1.SelectAllbusiness().ToList();
                    Global.buslist= buslist1.Where(x=>x.Sellerid.Id==Global.Seller.Id).ToList();
                    Global.connection.Close();
                }
                else
                {
                    textcodseler.Visibility = Visibility;
                       
                }

               }
               else
               {
                textfhonseler.Visibility = Visibility;
               }
            }
            else 
            {
                Global.Costumer = Global.Service1.selectbyphonecostumer(foncos.Text);
                if(Global.Costumer != null)
                {
                    if(Global.Costumer.Code== codcos.Text)
                    {
                        Global.MainWindow.frm.NavigationService.Navigate(new PageMainCostumer());
                        Global.MainWindow.myMenu.Visibility = Visibility.Visible; 
                        Global.MainWindow.business.Visibility = Visibility.Collapsed;
                        Global.MainWindow.chat.Visibility = Visibility.Collapsed;
                        Global.MainWindow.chatcos.Visibility = Visibility.Visible;
                        Global.connection.Close();
                    }
                    else
                    {
                        textcodcos.Visibility = Visibility; 
                    }
                }
                else
                {
                    textfhoncos.Visibility = Visibility;    
                }
            }

        }
    }
}
