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
    /// Interaction logic for ShipsView.xaml
    /// </summary>
    public partial class ShipsView : UserControl
    {
        Point anchorPoint;
        Point currentPoint;
        bool isInDrag = false;
        private TranslateTransform transform = new TranslateTransform();

        public ShipsView()
        {
            InitializeComponent();
        }

        private void root_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void root_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isInDrag)
            {
                var element = sender as FrameworkElement;
                element.ReleaseMouseCapture();
                isInDrag = false;
                e.Handled = true;
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void addBoatBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!TextBoatName.Text.Equals(string.Empty))
            {
                BoatList.Items.Add(new ListViewItem().Content = TextBoatName.Text);
            }

            CleanForm();
        }

        private void CleanForm()
        {
            TextBoatName.Text = string.Empty;
            TextFirstName.Text = string.Empty;
            TextLastName.Text = string.Empty;
            TextCountry.Text = string.Empty;
        }
    }
}
