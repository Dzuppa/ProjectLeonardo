using MahApps.Metro.Controls;
using NTT.Controls.ViewModels;
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

namespace NTT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();

            Notify.btnWithNotify.Click += BtnWithNotify_Click;
            
        }

        private void BtnWithNotify_Click(object sender, RoutedEventArgs e)
        {
            //AlarmsListViewModel ala = new AlarmsListViewModel();

            //AlarmsGrid.DataContext = ala;

            AlarmsGrid.Visibility = Visibility.Visible;
        }
    }
}
