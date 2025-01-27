using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF.UI.Converter
{
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = parameter == null;
            object result;
            if (flag)
            {
                bool flag2 = System.Convert.ToBoolean(value);
                if (flag2)
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Hidden;
                }
            }
            else
            {
                bool flag3 = System.Convert.ToBoolean(value);
                if (flag3)
                {
                    result = Visibility.Hidden;
                }
                else
                {
                    result = Visibility.Visible;
                }
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
