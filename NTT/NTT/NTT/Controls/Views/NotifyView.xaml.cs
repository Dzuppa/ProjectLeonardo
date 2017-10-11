using NTT.Controls.ViewModels;
using NTT.WebSocketManager;
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

namespace NTT.Controls.Views
{
    /// <summary>
    /// Interaction logic for AlarmsView.xaml
    /// </summary>
    public partial class NotifyView : UserControl
    {
        #region Fields

        Point anchorPoint;
        Point currentPoint;
        bool isInDrag = false;
        private TranslateTransform transform = new TranslateTransform();
        private EventAggregator eventAggregator;
        private WebSocketManager.WebSocketManager socketManager;

        #endregion

        #region Constructor

        public NotifyView()
        {
            
            InitializeComponent();

            eventAggregator = new EventAggregator();

            this.DataContext = new NotifyViewModel(eventAggregator);

            socketManager = new WebSocketManager.WebSocketManager(eventAggregator);

            Loaded += NotifyViews_Loaded;

        }

        #endregion

        #region BadgeEvents

        /// <summary>
        /// Evento Loaded per cambiare l'icona del bottone a seconda del numero di notifiche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyViews_Loaded(object sender, RoutedEventArgs e)
        {
            SetIcon();
        }

        /// <summary>
        /// Evento per cambiare l'icona del bottone a seconda del numero di notifiche dopo che il badge è cambiato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BadgedButton_BadgeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetIcon();
        }

        private void SetIcon()
        {
            if (!BadgedButton.Badge.Equals(0))
            {
                btnIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.BellRing;
            }
            else
            {
                btnIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Bell;
            }
        }

        #endregion

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
