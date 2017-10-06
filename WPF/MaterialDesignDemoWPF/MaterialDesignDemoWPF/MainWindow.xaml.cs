using MaterialDesignDemoWPF.Controls.Views;
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

namespace MaterialDesignDemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Btns

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.Background = Brushes.LightSkyBlue;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            btn.Background = Brushes.Transparent;
        }
        
        private void AirPButton_Click(object sender, RoutedEventArgs e)
        {
            AP.Visibility = Visibility.Visible;
        }

        private void PointsBtn_Click(object sender, RoutedEventArgs e)
        {
            Points.Visibility = Visibility.Visible;
        }

        private void AnchorBtn_Click(object sender, RoutedEventArgs e)
        {
            Ships.Visibility = Visibility.Visible;
            
        }

        private void BaseCampBtn_Click(object sender, RoutedEventArgs e)
        {
            BaseCamps.Visibility = Visibility.Visible;
        }



        #endregion


    }
}
