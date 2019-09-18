using System;
using Plugin.Media;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace pos
{
    public class Camera
    {
        public static async Task<string> TakePhoto(string directory)
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = directory,
                Name = $"{new DateTime().ToString()}.jpg",
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 80
            });

            return file == null ? "" : file.Path;
        }
    }
}
