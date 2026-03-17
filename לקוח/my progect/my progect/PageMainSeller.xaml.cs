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
    /// Interaction logic for PageMainSeller.xaml
    /// </summary>
    public partial class PageMainSeller : Page
    {
        List<Takendates> listt;
        public PageMainSeller()
        {
            InitializeComponent();
            text.Text =  "!" + Global.Seller.Firstname+ " "+"ברוך הבא" ;
            listt = Global.Service1.SelectAlltakendates().ToList();
            listt = listt.Where(x=> x.Sellerid.Id == Global.Seller.Id).ToList();
            foreach(Takendates t in listt)
            {
                DateTime d = t.Takendate;
                cld.BlackoutDates.Add(new CalendarDateRange(d));
            }
                
            

        }

        private void cld_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           // Calendar c= (Calendar)sender;

            DateTime dt = Convert.ToDateTime( cld.SelectedDate);
            
            //cld.BlackoutDates.Add(new CalendarDateRange(dt));
           // cld.BlackoutDates.Add(new CalendarDateRange(dt, dt));
            Takendates t = new Takendates();
            t.Sellerid = Global.Seller;
            t.Takendate= dt;
            Global.Service1.Inserttakendates(t);
           // listt.Add(t);
            cld.BlackoutDates.Clear();
            MessageBox.Show("התאריך נוסף בהצלחה!");
            Global.MainWindow.frm.Navigate(new PageMainSeller());

        }

        //private void personal_Selected(object sender, RoutedEventArgs e)
        //{
        //    this.NavigationService.Navigate(new personal());
        //}
    }
}
