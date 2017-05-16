﻿using System;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Converters
{
    public class PublishDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var publishDateString = value as string;
            if (string.IsNullOrEmpty(publishDateString))
            {
                return value;
            }
            var array = publishDateString.Split('-');
            return string.Format("{0}.{1}.{2}", array[0].Substring(2), array[1], array[2]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}