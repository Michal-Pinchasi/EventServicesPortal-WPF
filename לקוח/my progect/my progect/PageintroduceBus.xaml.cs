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
    /// Interaction logic for PageintroduceBus.xaml
    /// </summary>
    public partial class PageintroduceBus : Page
    { Business bu;
        int c;
        
        


        public PageintroduceBus(Business b, int cc)
        {
            InitializeComponent();
            this.DataContext = b;
            bu = b;    
            c=cc;

            try
            {
                Uri fileUri = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" + bu.Image1);
                img1.Source = new BitmapImage(fileUri);
                Uri fileUri2 = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" + bu.Image2);
                img2.Source = new BitmapImage(fileUri2);
                Uri fileUri3 = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" + bu.Image3);
                img3.Source = new BitmapImage(fileUri3);
            }
            catch
            {

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            smallchat c1 = new smallchat(c);
            c1.Show();
           
        }
    }
}
