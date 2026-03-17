using Microsoft.Win32;
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
    /// Interaction logic for Pagenewbusiness.xaml
    /// </summary>
    public partial class Pagenewbusiness : Page
    {
        Service1Client sc;
        Business c;
        string status;
        public Pagenewbusiness( string status,Business c)
        {
            InitializeComponent();
            sc = new Service1Client();

            cmbcategory.ItemsSource = sc.SelectAllcategories();
            this.c = c;
            this.DataContext = c;
            this.status = status;
            Global.buslist = new List<Business>();
            sellerid.Text = Global.Seller.Id.ToString();
            c.Sellerid = Global.Seller;

            try
            {
                Uri fileUri = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" +c.Image1 );
                img1.Source = new BitmapImage(fileUri);
                Uri fileUri2 = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" + c.Image2);
                img2.Source = new BitmapImage(fileUri2);
                Uri fileUri3 = new Uri(System.Windows.Forms.Application.StartupPath + @"\Pics\" + c.Image3);
                img3.Source = new BitmapImage(fileUri3);
            }
            catch
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (status == "new")
            {
                c.Image1 = picture1.Text;
                c.Image2=picture2.Text;
                c.Image3=picture3.Text;
                Global.Service1.Insertbusiness(c);
                c.Sellerid = Global.Seller;
                Global.MainWindow.frm.NavigationService.Navigate(new PageMainSeller());
                Global.MainWindow.myMenu.Visibility = Visibility.Visible;
                Global.MainWindow.chatcos.Visibility = Visibility.Collapsed;
                Global.buslist.Add(c);
                Global.connection.Close();
            }
            else
            {
                if( status=="old")
                {
                    c.Image1 = picture1.Text;
                    c.Image2 = picture2.Text;
                    c.Image3 = picture3.Text;
                    Global.Service1.Insertbusiness (c);
                    Global.buslist.Add(c);
                    Global.MainWindow.frm.NavigationService.Navigate( new PageBusinessSeller());
                    Global.MainWindow.myMenu.Visibility = Visibility.Visible;

                }
                else 
                {
                    c.Image1 = picture1.Text;
                    c.Image2 = picture2.Text;
                    c.Image3 = picture3.Text;
                    Global.Service1.Updatebusiness(c);
                    this.NavigationService.GoBack();
                }
            }
           
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Uri fileUri = new Uri(ofd.FileName);
                img1.Source = new BitmapImage(fileUri);
            }
            picture1.Text = ofd.SafeFileName;
            c.Image1  = picture1.Text;

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd2 = new OpenFileDialog();
            if (ofd2.ShowDialog() == true)
            {
                Uri fileUri = new Uri(ofd2.FileName);
                img2.Source = new BitmapImage(fileUri);
            }
            picture2 .Text = ofd2.SafeFileName;
            c.Image2  = picture2.Text;

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Uri fileUri = new Uri(ofd.FileName);
                img3 .Source = new BitmapImage(fileUri);
            }
            picture3.Text = ofd.SafeFileName;
            c.Image3  = picture3 .Text;

        }
    }
}
