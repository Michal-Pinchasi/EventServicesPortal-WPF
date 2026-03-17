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
    /// Interaction logic for personal.xaml
    /// </summary>
    public partial class personal : Page
    {
        public personal()
        {
            InitializeComponent();
            if(Global.Seller!=null)
            { 
            firstname.Text = Global.Seller.Firstname;
            lastname.Text = Global.Seller.Lastname;
            id.Text= Global.Seller.Id.ToString();
            phone.Text= Global.Seller.Phone.ToString();
            cod.Text=Global.Seller.Code.ToString();
            city.Text=Global.Seller.C1.Name.ToString();
            }
            else
            {
                firstname.Text = Global.Costumer.Firstname;
                lastname.Text = Global.Costumer.Lastname;
                id.Text = Global.Costumer.Id.ToString();
                phone.Text = Global.Costumer.Phone.ToString();
                cod.Text = Global.Costumer.Code.ToString();
                city.Text = Global.Costumer.C1.Name.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sts = "old";
            if (Global.Seller!=null)
            {
                this.NavigationService.Navigate(new Pagenewseller(Global.Seller, sts));
            }
            else
            {
                this.NavigationService.Navigate(new Pagenewcostumer(sts,Global.Costumer));
            }
           
        }
    }
}
