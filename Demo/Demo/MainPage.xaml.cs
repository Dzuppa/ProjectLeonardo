using Demo.BusinessLogic;
using Demo.Manipulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Book> Books;

        public MainPage()
        {
            GestureRecognizer recognizerTAB;
            GestureRecognizer recognizerSP;
            GestureRecognizer recognizeCAS;
            GestureRecognizer recognizeBC;
            ManipulationInputProcessor manipulationProcessor;

            this.InitializeComponent();

            InitOptions();

            //Create the gesture recognizer used to process the manipulation on the rectangle
            recognizerTAB = new GestureRecognizer();
            recognizerSP = new GestureRecognizer();
            recognizeCAS = new GestureRecognizer();
            recognizeBC = new GestureRecognizer();

            //Create the ManipulationInputProcessor which will listen for events on the 
            //rectangle, process them and update the rectangle position and rotation (size??)
            manipulationProcessor = new ManipulationInputProcessor(recognizerTAB, TAB, mainCanvas);
            manipulationProcessor = new ManipulationInputProcessor(recognizerSP, SP, mainCanvas);
            manipulationProcessor = new ManipulationInputProcessor(recognizeCAS, CAS, mainCanvas);
            manipulationProcessor = new ManipulationInputProcessor(recognizeBC, BC, mainCanvas);

            Books = BookManager.GetBooks();
        }

        private async void InitOptions()
        {
            await new MessageDialog("Your Demo is started").ShowAsync();
        }

        private async void Submit_Clicked(object sender, RoutedEventArgs e)
        {
            await new MessageDialog("Thank you, mate").ShowAsync();
        }

        private void SliderValue_Changed(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;

            if (sender != null)
            {
                SP.SliderHeader = "Value: " + slider.Value.ToString();
            }
        }

        private void CAS_Clicked(object sender, RoutedEventArgs e)
        {
            CAS.AfterSubmit = "Submitted!";
        }

        private void BlankButton_Clicked(object sender, RoutedEventArgs e)
        {
            Grid DynamicGrid = Utility.CreateGrid(3, Books.Count() + 1);
            DynamicGrid = Utility.AddHeaderToGrid(DynamicGrid, new List<string>(new string[] {"BookID", "Title", "Author" }));
            DynamicGrid = BookManager.AddBooksToGrid(DynamicGrid, Books);

            BC.Children.Add(DynamicGrid);

            BlankButton.IsEnabled = false;
        }
    }

    
}
