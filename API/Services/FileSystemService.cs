using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using API.Models;
using Microsoft.Extensions.Logging;

namespace API.Services
{
    public class FileSystemService : IFileSystemService
    {
        private readonly ILogger<FileSystemService> _logger;

        public FileSystemService(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<FileSystemService>();
        }

        public IList<DriveModel> GetDrives()
        {
            _logger.LogInformation($"Entering {Common.GetCaller()} method");

            var driveInfos = DriveInfo.GetDrives();

            var drives = from driveInfo in driveInfos
                         where driveInfo.IsReady
                         select new DriveModel(driveInfo);

            _logger.LogInformation($"Exiting {Common.GetCaller()} method");

            return drives.ToList();
        }

        public DriveModel GetDrive(string driveName)
        {
            _logger.LogInformation($"Entering {Common.GetCaller()} method");

            var driveInfo = new DriveInfo(driveName);

            _logger.LogInformation($"Exiting {Common.GetCaller()} method");

            return new DriveModel(driveInfo);
        }

        public IList<FileSystemObjectModel> GetFileSystemObjects(string path)
        {
            _logger.LogInformation($"Entering {Common.GetCaller()} method");

            var rootDirectory = new DirectoryInfo(path);

            var directories = from directoryInfo in rootDirectory.EnumerateDirectories()
                              select new FileSystemObjectModel(directoryInfo);

            var files = from fileInfo in rootDirectory.EnumerateFiles()
                        select new FileSystemObjectModel(fileInfo);

            var fileSystemObjects = directories.Concat(files);

            _logger.LogInformation($"Exiting {Common.GetCaller()} method");

            return fileSystemObjects.ToList();
        }
    }
}
