using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace VisualChart
{
    public class EnumToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Direction enumValue)
            {
                switch (enumValue)
                {
                    case Direction.Up:
                        return (double)Direction.Up;
                    case Direction.Down:
                        return (double)Direction.Down;
                    case Direction.Left:
                        return (double)Direction.Left;
                    case Direction.Right:
                        return (double)Direction.Right;
                    default:
                        return 0.0;
                }
            }
            return 0.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
