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

namespace MUIDemoWPF.Controls.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void APBtn_Click(object sender, RoutedEventArgs e)
        {
            AP.Visibility = Visibility.Visible;
        }

        private void Btn_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            this.Cursor = Cursors.Hand;

            btn.Background = Brushes.DarkBlue;
        }

        private void Btn_MouseLeave(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            this.Cursor = Cursors.Arrow;

            btn.Background = Brushes.Transparent;
        }

        private void BCBtn_Click(object sender, RoutedEventArgs e)
        {
            BC.Visibility = Visibility.Visible;
        }

        private void PointsBtn_Click(object sender, RoutedEventArgs e)
        {
            Points.Visibility = Visibility.Visible;
        }

        private void ShipsBtn_Click(object sender, RoutedEventArgs e)
        {
            Ships.Visibility = Visibility.Visible;
        }
    }
}
