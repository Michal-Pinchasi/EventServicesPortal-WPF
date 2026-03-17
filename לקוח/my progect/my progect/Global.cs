using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using my_progect.ServiceReference1;
using  System.ServiceModel;



namespace my_progect
{
    public static class Global
    {
        public static Service1Client Service1 = new Service1Client();
        public static Seller Seller;
        public static Costumer Costumer;
        public static MainWindow MainWindow;
        public static connection connection;
        public static smallchat smallchat;
        public static List<Business> buslist;
    }
    
}
