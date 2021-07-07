using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public interface IFileSystemService
    {
        DriveModel GetDrive(string driveName);
        IList<DriveModel> GetDrives();
        IList<FileSystemObjectModel> GetFileSystemObjects(string path);
    }
}
