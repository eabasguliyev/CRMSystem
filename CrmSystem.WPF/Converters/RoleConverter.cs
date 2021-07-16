using System;
using System.Globalization;
using System.Windows.Data;
using CrmSystem.Domain.Models;

namespace CrmSystem.WPF.Converters
{
    public class RoleOptionConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((RoleOption) (int) value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}