using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace JG.TechLearning.WPF.CarDiagnostic.UserControlNS.Controls
{
    public partial class CircularProgressBar : ProgressBar
    {
        public CircularProgressBar()
        {
            ValueChanged += CircularProgressBar_ValueChanged;
        }

        void CircularProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CircularProgressBar progressBar = sender as CircularProgressBar;

            double currentAngle = progressBar.Angle;
            double targetAngle = e.NewValue / progressBar.Maximum * 359.999;

            DoubleAnimation animation = new DoubleAnimation(currentAngle, targetAngle, TimeSpan.FromMilliseconds(500));
            progressBar.BeginAnimation(AngleProperty, animation, HandoffBehavior.SnapshotAndReplace);
        }

        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(0.0));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularProgressBar), new PropertyMetadata(10.0));
    }
}
