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
using static System.Net.Mime.MediaTypeNames;

namespace my_progect
{
    /// <summary>
    /// Interaction logic for UCbusiness.xaml
    /// </summary>
    public partial class UCbusiness : UserControl
    {
        Business bu;
        public UCbusiness(Business b)
        {
            InitializeComponent();
            this.DataContext =b;
            bu = b;
            try
            {
                Uri fileUri = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" + bu.Image1);
                img.Source = new BitmapImage(fileUri);
            }
            catch
            {

            }
        }

        private void text_Click(object sender, RoutedEventArgs e)
        { int c = bu.Sellerid.Id;
            Global.MainWindow.frm.NavigationService.Navigate(new PageintroduceBus(bu,c));
            //text.Tag = bu.Sellerid.Id;
            //c = Convert.ToInt32(((Button)sender).Tag);
           
        }
    }
}

    
  