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
    /// Interaction logic for connection.xaml
    /// </summary>
    public partial class connection : Window
    {
        public connection()
        {
            InitializeComponent();
            Global.connection = this;
            //this.WindowStyle = WindowStyle.None;
            //this.AllowsTransparency = true;
            //this.Background = Brushes.Transparent;
            //this.MouseDown += (sender, e) =>
            //{
            //    if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            //        this.DragMove();
            //};

        }
        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    base.OnRender(drawingContext);
        //    var radius = 20;
        //    var rect = new Rect(0, 0, ActualWidth, ActualHeight);
        //    var pen = new Pen(Brushes.Black, 1);
        //    drawingContext.DrawRoundedRectangle(Brushes.White, pen, rect, radius, radius);
        //}

       
    }
}
