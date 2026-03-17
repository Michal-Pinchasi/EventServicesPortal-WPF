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
    /// Interaction logic for Pageopen.xaml
    /// </summary>
    public partial class Pageopen : Page
    {
        public Pageopen()
        {
            InitializeComponent();
            
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            connection c1 = new connection();
            c1.Show();

        }
    }
}
