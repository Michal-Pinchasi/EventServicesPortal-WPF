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
    /// Interaction logic for Pagechat.xaml
    /// </summary>
    public partial class Pagechat : Page
    {
        List<Chat> chatsList = new List<Chat>();
        List<Chat> chatsList1 = new List<Chat>();
        List<Chat> chatsList2 = new List<Chat>();
        List<People> CostumerList = new List<People>();
        List<Costumer> CostumerList1;
        int c;

        public Pagechat()
        {
            InitializeComponent();
            CostumerList1 = Global.Service1.SelectAllcostumer().ToList();
            chatsList = Global.Service1.SelectAllChat().ToList();
            chatsList1 = chatsList.Where(x => x.PeopleAccept.Id == Global.Seller.Id || x.PeopleWriter.Id == Global.Seller.Id).ToList();



            foreach (Chat x in chatsList1)
            {
                if (CostumerList1.Where(c => c.Id == x.PeopleAccept.Id).ToList().Count > 0)
                {
                    if (CostumerList.Where(y => y.Id == x.PeopleAccept.Id).ToList().Count == 0 && x.Id != Global.Seller.Id)
                        CostumerList.Add(x.PeopleAccept);

                }
                if (CostumerList1.Where(c => c.Id == x.PeopleWriter.Id).ToList().Count > 0)
                {
                    if (CostumerList.Where(y => y.Id == x.PeopleWriter.Id).ToList().Count == 0 && x.Id != Global.Seller.Id)
                        CostumerList.Add(x.PeopleWriter);

                }

            }
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            foreach (People costumer in CostumerList)
            {
                Button btnPanelContent = new Button();
                btnPanelContent.Height = 80;
                btnPanelContent.Background = brush;


                btnPanelContent.Content = costumer.Firstname + " " + costumer.Lastname;
                btnPanelContent.Tag = costumer.Id;

                btnPanelContent.Click += new System.Windows.RoutedEventHandler(btn_Click);

                costumers.Children.Add(btnPanelContent);

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
            Chat chat1=new Chat();
            chat1.Remarks = Tcat.Text;
            chat1.ChatDate= DateTime.Now;
           
            chat1.Read = false;
           // chat1.Business = chatsList2[chatsList2.Count - 1].Business;
            Global.Service1.InsertCat(chat1, Global.Seller, Global.Service1.SelectByIdcostumer(c));
            chat1.PeopleWriter = Global.Seller;
            chat1.PeopleAccept = Global.Service1.SelectByIdcostumer(c);
            UCchat uc = new UCchat(chat1);
            uc.Height = 100;
            uc.Width = 320;
            remarkswin.Children.Add(uc);
            chatsList1.Add(chat1);
            Tcat.Text = "";
           
        }









        //foreach (Chat x in chatsList)
        //{

        //    //UCremarks ucr1 = new UCremarks(x);
        //    //ucr1.Height = 130;
        //    //ucr1.Width = 550;
        //    //ucr1.Margin = new Thickness(15);

        //    //remarkswin.Children.Add(ucr1);




        //}


        //    }
        //public Window1(TaskEmpl taskEmpl, UserControlTaskEmply1 user)//מקבל מצביע של היוזר כונטרול של המשימות עובדים כדאי שהסטטוס התעדכן באותו זמן שאני שולחת הודעה 
        //{
        //    InitializeComponent();
        //    BtasS.Visibility = Visibility.Visible;
        //    Ttasks.Visibility=Visibility.Visible;
        //    Tcat.Visibility = Visibility.Collapsed;
        //    Bcat.Visibility = Visibility.Collapsed;
        //    this.user1 = user;
        //    listtaskStatuses =User.Service1.SelectAllTS().ToList();
        //    listtaskStatuses = listtaskStatuses.Where(x => x.TaskEmpl.Id == taskEmpl.Id).ToList();
        //    foreach (TaskStatusA x in listtaskStatuses)
        //    {

        //            UCremarks ucr1 = new UCremarks(x);
        //            ucr1.Height = 130;
        //            ucr1.Width = 550;
        //            ucr1.Margin = new Thickness(15);

        //            remarkswin.Children.Add(ucr1);



        //    }

        //    liststatuses=User.Service1.SelectAllStause().ToList();
        //    cmbxnewstatus.ItemsSource = liststatuses;
        //    this.DataContext = tsta;
        //    tsta.StatusDate = DateTime.Now;
        //    tsta.TaskEmpl = taskEmpl;
        //}

        //public Window1(TaskEmpl taskEmpl, UserControlTaskEmpl user)
        //{
        //    InitializeComponent();

        //    BtasS.Visibility = Visibility.Visible;
        //    Ttasks.Visibility = Visibility.Visible;
        //    Tcat.Visibility = Visibility.Collapsed;
        //    Bcat.Visibility = Visibility.Collapsed;

        //    tsta.TaskEmpl = taskEmpl;
        //    this.user = user;
        //    listtaskStatuses = User.Service1.SelectAllTS().ToList();
        //    listtaskStatuses = listtaskStatuses.Where(x => x.TaskEmpl.Id == taskEmpl.Id).ToList();
        //    foreach (TaskStatusA x in listtaskStatuses)
        //    {


        //        UCremarks ucr1 = new UCremarks(x);
        //        ucr1.Height = 130;
        //        ucr1.Width = 550;
        //        ucr1.Margin = new Thickness(15);

        //        remarkswin.Children.Add(ucr1);




        //    }

        //    liststatuses = User.Service1.SelectAllStause().ToList();
        //    cmbxnewstatus.ItemsSource = liststatuses;
        //    this.DataContext = tsta;
        //    tsta.StatusDate = DateTime.Now;
        //    tsta.TaskEmpl = taskEmpl;
        //}




        //private void btnreok_Click(object sender, RoutedEventArgs e)
        //{

        //    Statuses = (Statuses)cmbxnewstatus.SelectedItem;
        //    tsta.IdStatuses = Statuses;
        //    if(User.emp.IsMenger)
        //    {
        //        tsta.IsMang = true;

        //    }
        //    else
        //    {
        //        tsta.IsMang = false;

        //    }

        //    User.Service1.InsertTS(tsta);

        //    UCremarks ucr = new UCremarks(tsta);
        //    ucr.Height = 130;
        //    ucr.Width = 550;
        //    ucr.Margin = new Thickness(15);
        //    remarkswin.Children.Add(ucr);
        //    if (user1 != null)
        //    {
        //        user1.SetV(tsta.IdStatuses.StatusName);
        //    }
        //    else
        //    {
        //        user.SetV(tsta.IdStatuses.StatusName);
        //    }

        //}

        //private void ClickEnd(object sender, RoutedEventArgs e)
        //{

        //    this.Close();
        //}

        //private void BT_Click(object sender, RoutedEventArgs e)
        //{
        //    Chat=new Chat();
        //    Chat.Employee = User.emp;
        //    Chat.StatusDate = DateTime.Now;

        //    Chat.Remarks = Tcat.Text;
        //    User.Service1.InsertCat(Chat);


        //    UCremarks ucr = new UCremarks(Chat);
        //    ucr.Height = 130;
        //    ucr.Width = 550;
        //    ucr.Margin = new Thickness(15);
        //    remarkswin.Children.Add(ucr);
        //}
        //}

    }
}
