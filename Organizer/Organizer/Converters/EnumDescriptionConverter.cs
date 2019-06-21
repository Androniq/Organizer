using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Organizer.Converters
{
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var member = memberInfo.FirstOrDefault(it => it.DeclaringType == type);
            if (member == null)
                return value.ToString();
            var attr = member.GetCustomAttribute<DescriptionAttribute>();
            return attr?.Description ?? value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
