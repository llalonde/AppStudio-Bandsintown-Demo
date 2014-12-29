using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace AppStudio.Controls
{
    public class TicketAvailableToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility = Visibility.Collapsed;
            if (value != null)
            {
                visibility = (value.ToString().ToLower().Equals("available")) ? 
                    Visibility.Visible : 
                    Visibility.Collapsed;
            }
            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}


