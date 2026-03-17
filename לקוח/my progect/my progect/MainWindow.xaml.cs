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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Global.MainWindow = this;
            

        }
        private void personal_Selected(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new personal());
        }

        private void business_Selected(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new PageBusinessSeller());
        }
        private void chat_Selected(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Pagechat());
        }
        private void chatcos_Selected(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Pagechatcostumer());
        }

        private void Home_Selected(object sender, RoutedEventArgs e)
        {if(Global.Seller!=null)
            frm.NavigationService.Navigate(new PageMainSeller());
        else
                frm.NavigationService.Navigate(new PageMainCostumer());
        }

        private void exit_Selected(object sender, RoutedEventArgs e)
        {
            frm.NavigationService.Navigate(new Pageopen());
            myMenu.Visibility = Visibility.Collapsed;
            Global.Seller = null;
            Global.Costumer = null;
            Global.buslist = null;
        }
    }
}
