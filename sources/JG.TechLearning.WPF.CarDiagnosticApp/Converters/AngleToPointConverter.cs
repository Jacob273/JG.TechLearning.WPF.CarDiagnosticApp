using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace JG.TechLearning.WPF.CarDiagnosticApp.Converters
{
    public class AngleToPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double angle = (double)value;
            double radius = 50;

            double px = Math.Sin(angle * Math.PI / 180) * radius + radius;
            double py = -Math.Cos(angle * Math.PI / 180) * radius + radius;

            return new Point(px, py);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
