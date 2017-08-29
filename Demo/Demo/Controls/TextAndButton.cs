using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace Demo.Controls
{
    public sealed class TextAndButton : MyControl
    {
        public TextAndButton()
        {
            this.DefaultStyleKey = typeof(TextAndButton);
        }

        Button _myButton;

        public event EventHandler<RoutedEventArgs> Clicked;

        protected override void OnApplyTemplate()
        {
            _myButton = GetTemplateChild<Button>("TBButton");

            //C# 6 ?. control if Cliked is null and if not use invoke (syntactic sugar)
            _myButton.Click += (s, e) => Clicked?.Invoke(s, e);
        }

        #region DependencyProporty



        public string CustomText
        {
            get { return (string)GetValue(CustomTextProperty); }
            set { SetValue(CustomTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomTextProperty =
            DependencyProperty.Register(nameof(CustomText), typeof(string), typeof(TextAndButton), new PropertyMetadata("Custom Text Here"));

        public double SetFontSize
        {
            get { return (double)GetValue(SetFontSizeProperty); }
            set { SetValue(SetFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetFontSizeProperty =
            DependencyProperty.Register(nameof(SetFontSize), typeof(double), typeof(TextAndButton), new PropertyMetadata(15));



        #endregion

    }




}
