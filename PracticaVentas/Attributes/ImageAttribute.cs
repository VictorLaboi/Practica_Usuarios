using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace PracticaVentas.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class ImageAttribute : ValidationAttribute
    {
        private readonly double _minWidth;
        private readonly double _minHeight;
        private readonly double _maxWidth;
        private readonly double _maxHeight;

        public ImageAttribute(double minWidth, double minHeight, double maxWidth, double maxHeight)
        {
            _minWidth = minWidth;
            _minHeight = minHeight;
            _maxWidth = maxWidth;
            _maxHeight = maxHeight;
        }

        public override bool IsValid(object? value)
        {
            if (value is BitmapImage bitmap)
            {
                return bitmap.Width >= _minWidth && bitmap.Height >= _minHeight
                    && bitmap.Width <= _maxWidth && bitmap.Height <= _maxHeight;
            }

            return false;
        }
    }
}



