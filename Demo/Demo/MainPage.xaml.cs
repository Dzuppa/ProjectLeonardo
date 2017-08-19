using Demo.Manipulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
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
        public MainPage()
        {
            GestureRecognizer recognizerTAB;
            GestureRecognizer recognizerSP;
            ManipulationInputProcessor manipulationProcessor;

            this.InitializeComponent();

            InitOptions();

            //Create the gesture recognizer used to process the manipulation on the rectangle
            recognizerTAB = new GestureRecognizer();
            recognizerSP = new GestureRecognizer();

            //Create the ManipulationInputProcessor which will listen for events on the 
            //rectangle, process them and update the rectangle position and rotation (size??)
            manipulationProcessor = new ManipulationInputProcessor(recognizerTAB, TAB, mainCanvas);
            manipulationProcessor = new ManipulationInputProcessor(recognizerSP, SP, mainCanvas);
        }

        private void InitOptions()
        {
            
        }
    }

    
}
