using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace Demo.Manipulation
{
    class ManipulationInputProcessor
    {
        GestureRecognizer recognizer;
        UIElement element;
        UIElement reference;
        TransformGroup cumulativeTransform;
        MatrixTransform previousTransform;
        CompositeTransform deltaTransform;

        public ManipulationInputProcessor(GestureRecognizer gestureRecognizer, UIElement target, UIElement referenceFrame)
        {
            recognizer = gestureRecognizer;
            element = target;
            reference = referenceFrame;

            //Initialize the transfom that will be used to manipulate the shape
            InitializeTransform();

            //Set what manipulation event the gesture recognizer will listen
            recognizer.GestureSettings = GenerateDefaultSetting();

            //Set pointer event handlers. These receive input events that are used by gesture recognizer
            element.PointerPressed += OnPointerPressed;
            element.PointerMoved += OnPointerMoved;
            element.PointerReleased += OnPointerRelease;
            element.PointerCanceled += OnPointerCanceled;

            //Set event handlers to respond gesture recognizer output
            recognizer.ManipulationStarted += OnManipulationStarted;
            recognizer.ManipulationUpdated += OnManipulationUpdated;
            recognizer.ManipulationCompleted += OnManipulationCompleted;
            recognizer.ManipulationInertiaStarting += OnManipulationInertiaStarting;
        }

        private void InitializeTransform()
        {
            cumulativeTransform = new TransformGroup();
            deltaTransform = new CompositeTransform();
            previousTransform = new MatrixTransform();

            cumulativeTransform.Children.Add(previousTransform);
            cumulativeTransform.Children.Add(deltaTransform);

            element.RenderTransform = cumulativeTransform;
        }

        private GestureSettings GenerateDefaultSetting()
        {
            return GestureSettings.ManipulationTranslateX |
                GestureSettings.ManipulationTranslateY |
                GestureSettings.ManipulationRotate;// |
                //GestureSettings.ManipulationTranslateInertia |
                //GestureSettings.ManipulationRotateInertia;
        }

        //Route the pointer pressed event to the gesture recognizer
        //the points are in the reference frame of the canvas that contains the rectangle element
        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            //Set the pointer capture to the element being interacted with so that only it will fire pointer-related events
            element.CapturePointer(e.Pointer);

            //Feed the current point into the gesture recognizer as a down event
            recognizer.ProcessDownEvent(e.GetCurrentPoint(reference));
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            recognizer.ProcessMoveEvents(e.GetIntermediatePoints(reference));
        }

        private void OnPointerRelease(object sender, PointerRoutedEventArgs e)
        {
            recognizer.ProcessUpEvent(e.GetCurrentPoint(reference));

            element.ReleasePointerCapture(e.Pointer);
        }

        private void OnPointerCanceled(object sender, PointerRoutedEventArgs e)
        {
            recognizer.CompleteGesture();
            element.ReleasePointerCapture(e.Pointer);
        }

        private void OnManipulationStarted(GestureRecognizer sender, ManipulationStartedEventArgs args)
        {
            //Border B = element as Border;
            //B.Background = new SolidColorBrush(Windows.UI.Colors.DeepSkyBlue);
        }

        private void OnManipulationUpdated(GestureRecognizer sender, ManipulationUpdatedEventArgs args)
        {
            previousTransform.Matrix = cumulativeTransform.Value;

            Point center = new Point(args.Position.X, args.Position.Y);
            deltaTransform.CenterX = center.X;
            deltaTransform.CenterY = center.Y;

            deltaTransform.Rotation = args.Delta.Rotation;
            deltaTransform.TranslateX = args.Delta.Translation.X;
            deltaTransform.TranslateY = args.Delta.Translation.Y;
        }

        private void OnManipulationInertiaStarting(GestureRecognizer sender, ManipulationInertiaStartingEventArgs args)
        {
            //Border b = element as Border;
            //b.Background = new SolidColorBrush(Windows.UI.Colors.RoyalBlue);
        }

        private void OnManipulationCompleted(GestureRecognizer sender, ManipulationCompletedEventArgs args)
        {
            //Border b = element as Border;
            //b.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
        }



    }
}
