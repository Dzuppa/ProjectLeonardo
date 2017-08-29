using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Demo.Controls
{
    public sealed class SliderPanel : MyControl
    {
        public SliderPanel()
        {
            this.DefaultStyleKey = typeof(SliderPanel);
        }

        Slider _mySlider;

        public event EventHandler<RangeBaseValueChangedEventArgs> ValueChanged;

        protected override void OnApplyTemplate()
        {
            _mySlider = GetTemplateChild<Slider>("SPSlider");

            //C# 6 ?. control if ValueChanged is null and if not use invoke (syntactic sugar)
            _mySlider.ValueChanged += (s, e) => ValueChanged?.Invoke(s, e);
        }

        public string SliderHeader
        {
            get { return (string)GetValue(SliderHeaderProperty); }
            set { SetValue(SliderHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SliderHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SliderHeaderProperty =
            DependencyProperty.Register(nameof(SliderHeader), typeof(string), typeof(SliderPanel), new PropertyMetadata("Header of the custom Slider"));

        public string PanelTitle
        {
            get { return (string)GetValue(PanelTitleProperty); }
            set { SetValue(PanelTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PanelTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PanelTitleProperty =
            DependencyProperty.Register(nameof(PanelTitle), typeof(string), typeof(SliderPanel), new PropertyMetadata("Title of the custom SliderPanel"));



        public double SetMinimum
        {
            get { return (double)GetValue(SetMinimumProperty); }
            set { SetValue(SetMinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetMinimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetMinimumProperty =
            DependencyProperty.Register(nameof(SetMinimum), typeof(double), typeof(SliderPanel), new PropertyMetadata(0));
        


        public double SetMaximum
        {
            get { return (double)GetValue(SetMaximumProperty); }
            set { SetValue(SetMaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetMaximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetMaximumProperty =
            DependencyProperty.Register(nameof(SetMaximum), typeof(double), typeof(SliderPanel), new PropertyMetadata(100));



    }
}
