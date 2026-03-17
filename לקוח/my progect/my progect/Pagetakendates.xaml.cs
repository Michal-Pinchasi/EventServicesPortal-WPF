
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
using System.ServiceModel;
using my_progect.ServiceReference1;

namespace my_progect
{
    /// <summary>
    /// Interaction logic for Pagetakendates.xaml
    /// </summary>
    public partial class Pagetakendates : Page
    {
        
        Takendates c;
        string status;
       
        public Pagetakendates(Takendates takendates,string status)
        {
            InitializeComponent();
            this.c = takendates;
            this.status = status;
            this.DataContext = c;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            c.Sellerid = Global.Service1.SelectByIdsekller(0);
            c.Takendate = DateTime.Today;
            if (status == "new")
                Global.Service1.Inserttakendates(c);
            else
                Global.Service1.Updatetakendates(c);
            this.NavigationService.GoBack();
        }
    }
}
