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
    /// Interaction logic for Pagechatcostumer.xaml
    /// </summary>
    public partial class Pagechatcostumer : Page
    {
        List<Chat> chatsList = new List<Chat>();
        List<Chat> chatsList1 = new List<Chat>();
        List<Chat> chatsList2 = new List<Chat>();
        List<People> sellerList = new List<People>();
        List<Seller> sellerList1;
        int c;
       
       

        public Pagechatcostumer()
        {
            InitializeComponent();
            sellerList1 = Global.Service1.SelectAllseller().ToList();//שליפת כל המוכרים
            chatsList = Global.Service1.SelectAllChat().ToList();//שליפת כל הצאטים
            chatsList1 = chatsList.Where(x => x.PeopleAccept.Id == Global.Costumer.Id || x.PeopleWriter.Id == Global.Costumer.Id).ToList();//סינון כל הצאטים שהלקוח שנכנס נמצא או ככותב ההודעה או כמקבל
         


            foreach (Chat x in chatsList1)//מעבר על כל הצאטים אחרי הסינון
            {
                if (sellerList1.Where(c => c.Id == x.PeopleAccept.Id).ToList().Count > 0)//בדיקה עבור כל צאט האם מקבל ההודעה הוא מסוג מוכר
                {
                    if (sellerList.Where(y => y.Id == x.PeopleAccept.Id).ToList().Count == 0 && x.Id != Global.Costumer.Id)// אם הוא מוכר בדקנו שלא נמצא כבר ברשימת המוכרים שנאספה ושזה לא הוא בעצמו
                        sellerList.Add(x.PeopleAccept);//אם כן הוא מוסיף אותו לרשימת המוכרים

                }
                if (sellerList1.Where(c => c.Id == x.PeopleWriter.Id).ToList().Count > 0)
                {
                    if (sellerList.Where(y => y.Id == x.PeopleWriter.Id).ToList().Count == 0 && x.Id != Global.Costumer.Id)
                        sellerList.Add(x.PeopleWriter);

                }

            }
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            foreach (People seller in sellerList)
            {
                Button btnPanelContent = new Button();
                btnPanelContent.Height = 80;
                btnPanelContent.Background = brush;


                btnPanelContent.Content = seller.Firstname + " " + seller.Lastname;
                btnPanelContent.Tag = seller.Id;

                btnPanelContent.Click += new System.Windows.RoutedEventHandler(btn_Click);

                sellers.Children.Add(btnPanelContent);
               

            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {

            c = Convert.ToInt32(((Button)sender).Tag);
            chatsList2 = chatsList1.Where(x => x.PeopleAccept.Id == c || x.PeopleWriter.Id == c).ToList();
            remarkswin.Children.Clear();
            foreach (Chat i in chatsList2)
            {
                UCchat uc = new UCchat(i);
                uc.Height = 100;
                uc.Width = 320;
                remarkswin.Children.Add(uc);
               
            }
            stac.Visibility = Visibility;
        }

        private void Bcat_Click(object sender, RoutedEventArgs e)
        {
            Chat chat1 = new Chat();
            chat1.Remarks = Tcat.Text;
            chat1.ChatDate = DateTime.Now;
            chat1.Read = false;
           

            //chat1.Business = chatsList2[chatsList2.Count - 1].Business;
            Global.Service1.InsertCat1(chat1,Global.Costumer, Global.Service1.SelectByIdsekller(c));
            chat1.PeopleWriter = Global.Costumer;
            chat1.PeopleAccept = Global.Service1.SelectByIdsekller(c);
            UCchat uc = new UCchat(chat1);
            uc.Height = 100;
            uc.Width = 320;
            remarkswin.Children.Add(uc);
            chatsList1.Add(chat1);
            Tcat.Text = "";
        }
    }
}
