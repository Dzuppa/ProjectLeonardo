using NTT.Controls.Models;
using NTT.Controls.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NTT.Controls.Views
{
    /// <summary>
    /// Interaction logic for AlarmsGridViewxaml.xaml
    /// </summary>
    public partial class AlarmsGridView : UserControl
    {
        Point anchorPoint;
        Point currentPoint;
        bool isInDrag = false;
        private TranslateTransform transform = new TranslateTransform();
        
        public AlarmsGridView()
        {
            InitializeComponent();

            //this.DataContext = new AlarmsListViewModel();

            dgAlarm.Loaded += SetMinWidths;
        }

        /// <summary>
        /// Evento per la selezione della riga della griglia degli allarmi
        /// Gestisce il doppio click del mouse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            AlarmsListViewModel dt = (AlarmsListViewModel)dg.DataContext;

            txt.Text = dt.AlarmsList[dg.SelectedIndex].Name;
        }

        /// <summary>
        /// Una volta che la griglia viene caricata setto la width
        /// delle colonne in maniera tale da riempire lo spazio rimanente
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public void SetMinWidths(object source, EventArgs e)
        {
            foreach (var column in dgAlarm.Columns)
            {
                column.MinWidth = column.ActualWidth;
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    //row.DetailsVisibility =
                    //row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    txt.Visibility = Visibility.Visible;
                    AlarmsModel model = (AlarmsModel)row.DataContext;
                    txt.Text = model.Name.ToString();
                    break;
                }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        #region MouseMove

        //eventi per la gestione del movimento tramite mouse

        private void root_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            anchorPoint = e.GetPosition(null);
            element.CaptureMouse();
            isInDrag = true;
            e.Handled = true;
        }

        private void root_MouseMove(object sender, MouseEventArgs e)
        {
            if (isInDrag)
            {
                var element = sender as FrameworkElement;
                currentPoint = e.GetPosition(null);

                transform.X += currentPoint.X - anchorPoint.X;
                transform.Y += (currentPoint.Y - anchorPoint.Y);
                this.RenderTransform = transform;
                anchorPoint = currentPoint;
            }
        }

        private void root_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isInDrag)
            {
                var element = sender as FrameworkElement;
                element.ReleaseMouseCapture();
                isInDrag = false;
                e.Handled = true;
            }
        }

        #endregion
    }
}
