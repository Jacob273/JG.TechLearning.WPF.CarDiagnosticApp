using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace JG.TechLearning.WPF.CarDiagnosticApp.Converters
{
    public class AngleToPointConverter : IValueConverter
    {
        private const double _radius = 50;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double angle = (double)value;

            //Input for Math.Sin() and Math.Cos() are radians, thats why we convert angle * PI/180
            double px = Math.Sin(angle * Math.PI / 180) * _radius + _radius;
            double py = -Math.Cos(angle * Math.PI / 180) * _radius + _radius;

            return new Point(px, py);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
