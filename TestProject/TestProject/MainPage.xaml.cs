using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Global rotate transform used for changing the angolation of 
        // the Panel based on input data from the button.
        private RotateTransform rotatePan;

        // Global translation transform used for changing the position of 
        // the Panel based on input data from the touch contact.
        private TranslateTransform dragTranslation;

        private CompositeTransform ct = new CompositeTransform();

        public MainPage()
        {
            this.InitializeComponent();

            //Initialize the rotate transform element and assign it to the SliderPanel control
            rotatePan = new RotateTransform();
            //Apply the translation to the Panel
            SliderPanel.RenderTransform = this.rotatePan;

            //// Listener for the ManipulationDelta event.
            Wrapper.ManipulationDelta += SliderPanel_manipulationDelta;
            //// New translation transform populated in 
            //// the ManipulationDelta handler.
            dragTranslation = new TranslateTransform();
            //// Apply the translation to the Wrapper.
            Wrapper.RenderTransform = this.dragTranslation;
        }

        #region btnRotate

        private void btnRotate_Click(object sender, RoutedEventArgs e)
        {
            AnimateProgressRingSlice(btnRotateTransform.Angle + 90);

        }


        private void AnimateProgressRingSlice(double to, double milliseconds = 350)
        {
            var storyboard = new Storyboard();
            var doubleanimation = new DoubleAnimation();
            doubleanimation.Duration = TimeSpan.FromMilliseconds(milliseconds);
            doubleanimation.EnableDependentAnimation = true;
            doubleanimation.To = to;
            Storyboard.SetTargetProperty(doubleanimation, "Angle");
            Storyboard.SetTarget(doubleanimation, btnRotateTransform);
            storyboard.Children.Add(doubleanimation);
            storyboard.Begin();
        }

        #endregion btnRotate

        #region slider

        private void volumeSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                txtSlider.Text = slider.Value.ToString();
            }
        }

        private void btnRotatePanel_Click(object sender, RoutedEventArgs e)
        {
            AnimatePanel(rotatePan.Angle + 90);
        }

        private void AnimatePanel(double to, double milliseconds = 350)
        {
            var storyboard = new Storyboard();
            var da = new DoubleAnimation();
            da.Duration = TimeSpan.FromMilliseconds(milliseconds);
            da.EnableDependentAnimation = true;
            da.To = to;
            Storyboard.SetTargetProperty(da, "Angle");
            Storyboard.SetTarget(da, SliderPanel.RenderTransform);
            storyboard.Children.Add(da);
            storyboard.Begin();
        }

        private void SliderPanel_manipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            // Move the Panel.
            dragTranslation.X += e.Delta.Translation.X;
            dragTranslation.Y += e.Delta.Translation.Y;
        }

        #endregion

    }
}
