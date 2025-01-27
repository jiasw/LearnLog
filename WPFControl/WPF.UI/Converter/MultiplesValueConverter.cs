using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPF.UI.Converter
{
    public class MultiplesValueConverter : IValueConverter
    {
        // Token: 0x0600088A RID: 2186 RVA: 0x0004A4D8 File Offset: 0x000486D8
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = parameter == null;
            object result;
            if (flag)
            {
                result = value;
            }
            else
            {
                result = System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
            }
            return result;
        }

        // Token: 0x0600088B RID: 2187 RVA: 0x0004A50C File Offset: 0x0004870C
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
