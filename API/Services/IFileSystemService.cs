using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IFileSystemService
    {
        Task<DriveModel> GetDrive(string driveName);
        Task<IList<DriveModel>> GetDrives();
        Task<IList<FileSystemObjectModel>> GetFileSystemObjects(string path);
    }
}
