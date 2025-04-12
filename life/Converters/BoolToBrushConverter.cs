using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace life.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        public Brush AliveBrush { get; set; }
        public Brush DeadBrush { get; set; }

        public object Convert(object value, Type type, object param, CultureInfo _)
        {
            if (value is bool isAlive)
                return isAlive ? AliveBrush : DeadBrush;
            return DeadBrush;
        }

        public object ConvertBack(object value, Type type, object param, CultureInfo _)
                 => throw new NotImplementedException();
    }
}
