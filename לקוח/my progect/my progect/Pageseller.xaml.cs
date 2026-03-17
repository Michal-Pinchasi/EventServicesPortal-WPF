
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
using System.ServiceModel;
using my_progect.ServiceReference1;

namespace my_progect
{
    /// <summary>
    /// Interaction logic for Pageseller.xaml
    /// </summary>
    public partial class Pageseller : Page
    {
  
        Seller c;
        string status;
        
       
        public Pageseller(Seller c, string status)
        {
            InitializeComponent();
            
            cmbcity.ItemsSource = Global.Service1.SelectAllcity(); 
            this.c = c;
            this.DataContext = c;
            this.status = status;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (status == "new")
                Global.Service1.Insertseller(c);
            else
                Global.Service1.Updateseller(c);
            this.NavigationService.GoBack();
        }
    }
}
