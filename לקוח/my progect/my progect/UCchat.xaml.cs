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
    /// Interaction logic for UCchat.xaml
    /// </summary>
    public partial class UCchat : UserControl
    {
        public UCchat(Chat c)
        {
            InitializeComponent();
            this.DataContext = c;

            if (c.Read == false)
            {
                text.FontWeight = FontWeights.Bold;
            }

            SolidColorBrush brush = new SolidColorBrush(Colors.LightGray);
            SolidColorBrush brush1 = new SolidColorBrush(Colors.LightSteelBlue);
           if (Global.Seller!=null)
            {
                if (c.PeopleWriter.Id == Global.Seller.Id)
            {
                    border.Background = brush;
                }
            else
                {
                    border.Background = brush1;
                }
            }
           else
            {
                if ( c.PeopleWriter.Id == Global.Costumer.Id)
            {
                    border.Background = brush;
                }
            else
                {
                    border.Background = brush1;
                }
            }

            

            name.Text = Global.Service1.SelectByIdpeople(c.PeopleWriter.Id).Firstname;
        }
    }
}
