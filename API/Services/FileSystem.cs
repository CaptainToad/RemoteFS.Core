using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Models;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public class FileSystem
    {
        private readonly ILogger<FileSystem> _logger;

        public FileSystem(ILogger<FileSystem> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Drive> GetDrives()
        {
            var driveInfos = DriveInfo.GetDrives();

            var drives = from driveInfo in driveInfos
                         where driveInfo.IsReady
                         select new Drive(driveInfo);

            return drives;
        }

        public Drive GetDrive(string driveName)
        {
            var driveInfo = new DriveInfo(driveName);

            return new Drive(driveInfo);
        }

        public IEnumerable<FileSystemObject> GetFileSystemObjects(string path)
        {
            var rootDirectory = new DirectoryInfo(path);

            var directories = from directoryInfo in rootDirectory.EnumerateDirectories()
                              select new FileSystemObject(directoryInfo);

            var files = from fileInfo in rootDirectory.EnumerateFiles()
                        select new FileSystemObject(fileInfo);

            var fileSystemObjects = directories.Concat(files);

            return fileSystemObjects;
        }
    }
}
