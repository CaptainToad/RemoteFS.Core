using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
