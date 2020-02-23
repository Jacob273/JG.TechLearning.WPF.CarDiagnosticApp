using JG.TechLearning.WPF.CarDiagnosticApp.Enums;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace JG.TechLearning.WPF.CarDiagnosticApp.Converters
{
    public class SeverityToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            LogInfoSeverity severity = LogInfoSeverity.Unknown;

            severity = (LogInfoSeverity)value;

            switch (severity)
            {
                case LogInfoSeverity.Error:
                    return (SolidColorBrush)Application.Current.Resources["RedBrush"];

                case LogInfoSeverity.Info:
                    return (SolidColorBrush)Application.Current.Resources["GreenBrush"];

                case LogInfoSeverity.Warning:
                    return (SolidColorBrush)Application.Current.Resources["OrangeBrush"];

                default:
                    return (SolidColorBrush)Application.Current.Resources["VeryVeryLightBlueBrush"];
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
