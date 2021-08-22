using System;
using System.Threading.Tasks;
using API.Services;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace APITests.Services
{
    [TestFixture()]
    public class FileSystemServiceTests
    {
        private FileSystemService _fileSystemService;

        [SetUp]
        public void Setup()
        {
            var loggerMock = new Moq.Mock<NullLoggerFactory>();
            _fileSystemService = new FileSystemService(loggerMock.Object);
        }

        [Test()]
        public async Task GetDrives_NoParameters_ReturnsListOfDrives()
        {
            var drives = await _fileSystemService.GetDrives();

            Assert.That(drives, Has.Count.GreaterThan(0));
        }

        [Test()]
        public async Task GetDrive_DriveC_ReturnsDrive()
        {
            var drive = await _fileSystemService.GetDrive("C");

            Assert.That(drive, Has.Property("Name").EqualTo("C:\\"));
        }

        [Test()]
        public async Task GetFileSystemObjects_GetProgramFilesDirectory_ReturnsFileSystemObject()
        {
            var directories = await _fileSystemService.GetFileSystemObjects("C:\\Program Files");

            Assert.That(directories, Has.Count.GreaterThan(0));
            Assert.That(directories[0], Has.Property("Exists").EqualTo(true));
            Assert.That(directories[0], Has.Property("IsDirectory").EqualTo(true));
            Assert.That(directories[0], Has.Property("ParentName").EqualTo("C:\\Program Files"));
        }

        [Test()]
        public void GetFileSystemObjects_GetNonExistentDirectory_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => _fileSystemService.GetFileSystemObjects("C:\\Does\\not\\exist").Wait());
        }
    }
}