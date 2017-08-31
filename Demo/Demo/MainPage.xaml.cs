using Demo.BusinessLogic;
using Demo.Manipulation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Demo.BusinessLogic.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Demo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int booksCount = 0;

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
            
        }
        

        private async void InitOptions()
        {
            //using (var db = new BooksContext())
            //{
            //    var book1 = new Book { BookId = 1, Title = "Vulpate", Author = "Futurum", CoverImage = "Assets/1.png" };
            //    var book2 = new Book { BookId = 2, Title = "Mazim", Author = "Sequiter Que", CoverImage = "Assets/2.png" };
            //    var book3 = new Book { BookId = 3, Title = "Elit", Author = "Tempor", CoverImage = "Assets/3.png" };

            //    db.Books.Add(book1);
            //    db.Books.Add(book2);
            //    db.Books.Add(book3);

            //    booksCount = db.Books.Count();

            //    db.SaveChanges();

            //}

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
            List<Book> books = DBUtility.GetBookList();

            CreateBooksPanel(books);
            
            BlankButton.IsEnabled = false;
        }

        private void CreateBooksPanel(List<Book> books)
        {
            int i = 1;

            foreach(var book in books)
            {
                TextBlock txt = new TextBlock();
                txt.Text = string.Concat(i,": '", book.Title, "' - ", book.Author);
                StackBook.Children.Add(txt);
                i++;
            }
        }
    }

    
}
