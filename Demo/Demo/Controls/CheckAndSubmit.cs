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
    public sealed class CheckAndSubmit : MyControl
    {
        public CheckAndSubmit()
        {
            this.DefaultStyleKey = typeof(CheckAndSubmit);
        }

        CheckBox _myCheckbox;
        Button _myButton;

        public event EventHandler<RoutedEventArgs> Clicked;
        public event EventHandler<RoutedEventArgs> Checked;

        protected override void OnApplyTemplate()
        {
            _myButton = GetTemplateChild<Button>("CSButton");
            _myCheckbox = GetTemplateChild<CheckBox>("CSCheckbox");

            //C# 6 ?. control if Cliked is null and if not use invoke (syntactic sugar)
            _myButton.Click += (s, e) => Clicked?.Invoke(s, e);
            _myCheckbox.Click += (s, e) => Checked?.Invoke(s, e);
        }

        public string CheckText
        {
            get { return (string)GetValue(CheckTextProperty); }
            set { SetValue(CheckTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CheckText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckTextProperty =
            DependencyProperty.Register(nameof(CheckText), typeof(string), typeof(CheckAndSubmit), new PropertyMetadata("I Agree"));


        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register(nameof(ButtonText), typeof(string), typeof(CheckAndSubmit), new PropertyMetadata("Submit"));



        public string TermsAndConditionsText
        {
            get { return (string)GetValue(TermsAndConditionsTextProperty); }
            set { SetValue(TermsAndConditionsTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TermsAndConditionsText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TermsAndConditionsTextProperty =
            DependencyProperty.Register(nameof(TermsAndConditionsText), typeof(string), typeof(CheckAndSubmit), new PropertyMetadata("Put here your terms and conditions"));



        public string AfterSubmit
        {
            get { return (string)GetValue(AfterSubmitProperty); }
            set { SetValue(AfterSubmitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AfterSubmit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AfterSubmitProperty =
            DependencyProperty.Register(nameof(AfterSubmit), typeof(string), typeof(CheckAndSubmit), new PropertyMetadata(""));



    }
}
