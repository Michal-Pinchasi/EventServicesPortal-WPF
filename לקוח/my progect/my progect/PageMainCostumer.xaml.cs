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
    /// Interaction logic for PageMainCostumer.xaml
    /// </summary>
    public partial class PageMainCostumer : Page
    {
        Service1Client sc;
        List<Business> lstbusiness;
        List<Business> lstbusiness2;
        UCbusiness ucbu;
        UCbusiness[] arr;

        DateTime Time=new DateTime();
        List<Seller> sellerList11;
        List<Seller> sellerList12=new List<Seller>();
        List<Takendates> takendates;
        List<Takendates> takendates1;
        List<Business> business;
        List<Business> business1;

        int c;

       

        public PageMainCostumer()
        {
            InitializeComponent();
            sc = new Service1Client();
            //DateTime Time = dpic.SelectedDate.HasValue ? dpic.SelectedDate.Value : DateTime.Now;
            //sellerList11 = Global.Service1.SelectAllseller().ToList();
            //takendates = Global.Service1.SelectAlltakendates().ToList();
            //foreach (Seller i in sellerList11) //מעבר על כל המוכרים
            //{
            //    foreach (Takendates y in takendates)//סינון תאריכים תפוסים של כל מוכר
            //    {
            //        takendates1 = takendates.Where(x => y.Sellerid.Id == i.Id).ToList();// רשימה של כל התאריכים התפוסים של אותו מוכר

            //    }
            //    foreach (Takendates z in takendates1)//מעבר על הרשימה של התאריכים התפוסים שלו
            //    {
            //        if(Time==z.Takendate)//אם התאריך לא תפוס הכנס את המוכר לרשימה
            //        {

            //        }
            //        else
            //        {
            //            sellerList12.Add(z.Sellerid);
            //        }   
            //    }
            //}
            //business= Global.Service1.SelectAllbusiness().ToList();//רשימת כל העסקים
            //foreach (Business m in business)//מעבר על כל העסקים והכנסת כל העסקים שהמוכר שלהם ברשימת המוכרים הפנויים 
            //{
            //    foreach (Business l in business)
            //    {
            //        business1 = business.Where(x => m.Sellerid.Id == l.Id).ToList();
            //    }
                    

            //}


            cmbcategory.ItemsSource = sc.SelectAllcategories();
            lstbusiness = Global.Service1.SelectAllbusiness().ToList();
            foreach (Business i in lstbusiness)
            {
                UCbusiness uc = new UCbusiness(i);
                uc.Height = 370;
                uc.Width = 320;
                stcbus.Children.Add(uc);

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)/*סינון*/
        {
            if (cmbcategory.SelectedItem != null)
            {
                stcbus.Children.Clear();
                lstbusiness2 = lstbusiness.Where(x => x.Categoriesid.Id == ((Categories)(cmbcategory.SelectedItem)).Id).ToList();
                arr = new UCbusiness[lstbusiness2.Count];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new UCbusiness(lstbusiness2[i]);
                    this.stcbus.Children.Add(arr[i]);
                }

            }
        if(dpic.SelectedDate.HasValue)
            {
                DateTime Time = dpic.SelectedDate.HasValue ? dpic.SelectedDate.Value : DateTime.Now;
                sellerList11 = Global.Service1.SelectAllseller().ToList();
                takendates = Global.Service1.SelectAlltakendates().ToList();
                foreach (Seller i in sellerList11) //מעבר על כל המוכרים
                {
                    foreach (Takendates y in takendates)//סינון תאריכים תפוסים של כל מוכר
                    {
                        takendates1 = takendates.Where(x => y.Sellerid.Id == i.Id).ToList();// רשימה של כל התאריכים התפוסים של אותו מוכר

                    }
                    foreach (Takendates z in takendates1)//מעבר על הרשימה של התאריכים התפוסים שלו
                    {
                        if (Time == z.Takendate)//אם התאריך לא תפוס הכנס את המוכר לרשימה
                        {

                        }
                        else
                        {
                            sellerList12.Add(z.Sellerid);
                        }
                    }
                }
                business = Global.Service1.SelectAllbusiness().ToList();//רשימת כל העסקים
                foreach (Business m in business)//מעבר על כל העסקים והכנסת כל העסקים שהמוכר שלהם ברשימת המוכרים הפנויים 
                {
                    foreach (Business l in business)
                    {
                        business1 = business.Where(x => m.Sellerid.Id == l.Id).ToList();
                    }


                }

                stcbus.Children.Clear();
                arr = new UCbusiness[business1.Count];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new UCbusiness(business1[i]);
                    this.stcbus.Children.Add(arr[i]);
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            stcbus.Children.Clear();
            cmbcategory.Text = null;
            foreach (Business i in lstbusiness)
            {
                UCbusiness uc = new UCbusiness(i);
                //uc.Height = 100;
                //uc.Width = 320;
                stcbus.Children.Add(uc);

            }
        }

        private void fonsel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (stcbus!=null)
            {
                stcbus.Children.Clear();
                lstbusiness2 = lstbusiness.Where(x => x.Sellerid.Firstname.StartsWith(fonsel.Text)).ToList();
                arr = new UCbusiness[lstbusiness2.Count];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new UCbusiness(lstbusiness2[i]);
                    this.stcbus.Children.Add(arr[i]);
                }
            }
                
           
           
           
        }

       
    }
}
