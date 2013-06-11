using System;
using System.Windows;
using Microsoft.Phone.Applications.Common;

namespace Parallax.Demo.WinPhone
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            AccelerometerHelper.Instance.Calibrate(true, true);

            AccelerometerHelper.Instance.ReadingChanged += OnAccelerometerHelperReadingChanged;
            AccelerometerHelper.Instance.Active = true;
        }

        private void OnAccelerometerHelperReadingChanged(object sender, AccelerometerHelperReadingEventArgs e)
        {
            var x = e.AverageAcceleration.X * -64.0;
            var y = e.AverageAcceleration.Y * -64.0;

            Dispatcher.BeginInvoke(() =>
            {
                BackgroundTransform.X = Math.Max(-24, Math.Min(24, x));
                BackgroundTransform.Y = Math.Max(-24, Math.Min(24, y));
            });
        }
    }
}