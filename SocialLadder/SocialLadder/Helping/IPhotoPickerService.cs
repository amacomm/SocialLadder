using System.IO;
using System.Threading.Tasks;

namespace SocialLadder
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
