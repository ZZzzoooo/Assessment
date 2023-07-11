using System;
using System.Globalization;
using Xamarin.Forms;

namespace UndoAssessment.Converters
{
    //ToDo: the converter can be replace from the Xamarin Community Toolkit package
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
