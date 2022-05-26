using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfUserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MomentaryNotification : UserControl
    {
        private Window _window;
        private bool _acknowledge;
        private string _text = "";
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
            }
        }

        private double _displayedTime = 0.5;
        public double DisplayedTime
        {
            get { return _displayedTime; }
            set { _displayedTime = value; }
        }

        private double _fadeTime = 1;

        public double FadeTime
        {
            get { return _fadeTime; }
            set { _fadeTime = value; }
        }

        /*public MomentaryNotification()
        {
            InitializeComponent();
            _window = Window.GetWindow(this);
            Visibility = Visibility.Collapsed;
            Width = 300;
            Height = 100;
        }*/

        public MomentaryNotification(string displayText, bool acknowledge = false, double? displayedTime = null, double? fadeTime = null, double? width = null, double? height = null, Thickness? borderThickness = null, Brush? borderBrush = null, Brush? backgroundBrush = null, Brush? foregroundBrush = null, Window? sender = null)
        {
            InitializeComponent();
            _acknowledge = acknowledge;
            Width = 300;
            Height = 100;
            Text = displayText;
            if (displayedTime is not null) DisplayedTime = (double)displayedTime;
            if (fadeTime is not null) FadeTime = (double)fadeTime;
            if (width is not null) Width = (double)width;
            if (height is not null) Height = (double)height;
            if (backgroundBrush is not null) Background = (Brush)backgroundBrush;
            if (foregroundBrush is not null) Foreground = (Brush)foregroundBrush;
            if (borderBrush is not null) BorderBrush = (Brush)borderBrush;
            if (borderThickness is not null) BorderThickness = (Thickness)borderThickness;
            if (sender is not null)
            {
                _window = sender;
            }
            else
            {
                _window = Application.Current.MainWindow;
            }
            subscribeToWindowEvents();
            Visibility = Visibility.Collapsed;
            Show();
        }

        private void subscribeToWindowEvents()
        {
            _window.MouseDown += startClose;
            _window.KeyUp += startClose;
        }

        public void Show()
        {
            ChangeWindowState(false);
            textDisplay.Text = Text;
            Visibility = Visibility.Visible;

            if (!_acknowledge)
            {
                int seconds = (int)DisplayedTime;
                int millis = (int)((DisplayedTime - (int)DisplayedTime) * 10);
                DispatcherTimer timer = new();
                timer.Tick += new EventHandler(Fade);
                timer.Interval = new TimeSpan(0, 0, 0, seconds, millis);
                timer.Start();
            }
        }

        private void ChangeWindowState(bool state)
        {
            foreach (Control c in FindVisualChildren<Control>(_window))
            {
                c.IsEnabled = state;
            }
        }

        private void Fade(object? sender, EventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, TimeSpan.FromSeconds(FadeTime));
            BeginAnimation(OpacityProperty, animation);

            int seconds = (int)FadeTime;
            int millis = (int)((FadeTime - (int)FadeTime) * 10);
            DispatcherTimer timer = new();
            timer.Tick += new EventHandler(OnDispose);
            timer.Interval = new TimeSpan(0, 0, 0, seconds, millis);
            timer.Start();
            if (sender.GetType() == typeof(DispatcherTimer))
            {
                (sender as DispatcherTimer).Stop();
            }

        }

        private void OnDispose(object? sender, EventArgs e)
        {
            Grid ParentControl = Parent as Grid;
            if (ParentControl != null)
            {
                ParentControl.Children.Remove(this);
            }
            if (sender.GetType() == typeof(DispatcherTimer))
            {
                (sender as DispatcherTimer).Stop();
            }
            
        }

        private void startClose(object sender, EventArgs e)
        {
            Fade(this, e);
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            ChangeWindowState(true);
        }
    }
}