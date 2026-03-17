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
using System.Windows.Shapes;

namespace my_progect
{
    /// <summary>
    /// Interaction logic for smallchat.xaml
    /// </summary>
    public partial class smallchat : Window
    {
        List<Chat> chatsList = new List<Chat>();
        List<Chat> chatsList2 = new List<Chat>();
        List<Chat> chatsList3 = new List<Chat>();
        int cc;
        public smallchat(int c)
        {
            InitializeComponent();
            cc = c;/*ת.ז בעל עסק*/
            chatsList = Global.Service1.SelectAllChat().ToList();//שליפת כל הצאטים
           
              
            chatsList2 = chatsList.Where(x => x.PeopleAccept.Id == Global.Costumer.Id || x.PeopleWriter.Id == Global.Costumer.Id ).ToList();/*הצאטים של שניהם*/
            chatsList3 = chatsList2.Where(x =>  x.PeopleAccept.Id == cc || x.PeopleWriter.Id == cc).ToList();/*הצאטים של שניהם*/
                remarkswin.Children.Clear();
           
            foreach (Chat i in chatsList3)
            {
                UCchat uc = new UCchat(i);
                uc.Height = 100;
                uc.Width = 320;
                remarkswin.Children.Add(uc);

            }


        }

        private void Bcat_Click(object sender, RoutedEventArgs e)
        {
         
                Chat chat1 = new Chat();
                chat1.Remarks = Tcat.Text;
                chat1.ChatDate = DateTime.Now;
                chat1.Read = false;


                //chat1.Business = chatsList2[chatsList2.Count - 1].Business;
                Global.Service1.InsertCat1(chat1, Global.Costumer, Global.Service1.SelectByIdsekller(cc));
                chat1.PeopleWriter = Global.Costumer;
                chat1.PeopleAccept = Global.Service1.SelectByIdsekller(cc);
                UCchat uc = new UCchat(chat1);
                uc.Height = 100;
                uc.Width = 320;
                remarkswin.Children.Add(uc);
                chatsList2.Add(chat1);
                Tcat.Text = "";
            
        }

      
    }
}
