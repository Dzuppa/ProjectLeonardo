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
    }
}
