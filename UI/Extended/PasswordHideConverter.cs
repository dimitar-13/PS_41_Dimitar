using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UI.Extended
{
    public class PasswordHideConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string valueToString = value?.ToString() ?? string.Empty;
                bool isPasswordHidden = bool.Parse(parameter.ToString());

                return isPasswordHidden ? new string('*', valueToString.Length) : valueToString;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
