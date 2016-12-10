using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TEC.Core.ComponentModel;

namespace WpfApplication1.Converters
{
    [ValueConversion(typeof(Operation), typeof(String))]
    public class OperationAndStringConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Operation)value).getEnumDescription();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().getEnumSingle<Operation>();
        }

    }
}
