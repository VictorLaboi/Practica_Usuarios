using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PracticaVentas.Servicios
{
    public static class Checkers
    {
        public static string? MessageError { get; set; } 

        public static bool CheckField(object j)
        {

            if (j == null) return false;

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(j);

            if (!Validator.TryValidateObject(j, context, validationResults, validateAllProperties: true))
            {
                MessageError = string.Join("\n", validationResults.Select(x => x.ErrorMessage));
                return false;
            }

            return true;
        }

        public static Byte[] ImageToByte(BitmapImage imageSource)
        {
            byte[] data = null;
            using (MemoryStream memoryStream = new MemoryStream()) {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(imageSource));
                encoder.Save(memoryStream);
                data = memoryStream.ToArray();  
            }
            return data;
        }

        public static BitmapImage ToImage(byte[] array)
        {
            if (array == null || array.Length == 0)
                return new BitmapImage();

            var image = new BitmapImage();
            using (var ms = new MemoryStream(array))
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // Cargar en memoria
                image.StreamSource = ms;
                image.EndInit();
                image.Freeze(); // Evita problemas con la UI
            }
            return image;
        }


    }
}
