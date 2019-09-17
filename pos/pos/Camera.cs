using System;
using Plugin.Media;
using System.Threading.Tasks;

namespace pos
{
    public class Camera
    {
        public static async Task<string> TakePhoto(string directory)
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = directory,
                Name = $"{new DateTime().ToString()}.jpg"
            });

            return file == null ? "" : file.Path;
        }
    }
}
