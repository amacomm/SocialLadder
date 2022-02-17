using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SocialLadder
{
    class ImageByte
    {
        public static ImageSource BytesToImage(byte[] bytes)//преобразование массива байтов в картинку
        {
            Stream stream = new MemoryStream(bytes);
            return ImageSource.FromStream(() => stream);
        }
        
        public static byte[] GetImageBytes(Stream stream) // Перевод картинки из потока в массив байтов
        {
        byte[] ImageBytes;
        using (var memoryStream = new System.IO.MemoryStream())
        {
            stream.CopyTo(memoryStream);
            ImageBytes = memoryStream.ToArray();
        }
        return ImageBytes;
        }
    }

    
}
