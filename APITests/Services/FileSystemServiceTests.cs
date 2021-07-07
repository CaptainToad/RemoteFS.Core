using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services.Tests
{
    [TestFixture()]
    public class FileSystemServiceTests
    {
        private FileSystemService _FileSystemService;

        [SetUp]
        public void Setup()
        {
            var loggerMock = new Moq.Mock<NullLoggerFactory>();
            _FileSystemService = new FileSystemService(loggerMock.Object);
        }

        [Test()]
        public async Task GetDrives_NoParameters_ReturnsListOfDrives()
        {
            var drives = await _FileSystemService.GetDrives();

            Assert.That(drives, Has.Count.GreaterThan(0));
        }

        [Test()]
        public async Task GetDrive_DriveC_ReturnsDrive()
        {
            var drive = await _FileSystemService.GetDrive("C");

            Assert.That(drive, Has.Property("Name").EqualTo("C:\\"));
        }

        [Test()]
        public async Task GetFileSystemObjects_GetProgramFilesDirectory_ReturnsFileSystemObject()
        {
            var directories = await _FileSystemService.GetFileSystemObjects("C:\\Program Files");

            Assert.That(directories, Has.Count.GreaterThan(0));
            Assert.That(directories[0], Has.Property("Exists").EqualTo(true));
            Assert.That(directories[0], Has.Property("IsDirectory").EqualTo(true));
            Assert.That(directories[0], Has.Property("ParentName").EqualTo("C:\\Program Files"));
        }

        [Test()]
        public void GetFileSystemObjects_GetNonExistentDirectory_ThrowsException()
        {
            Assert.Throws<AggregateException>(() => _FileSystemService.GetFileSystemObjects("C:\\Does\\not\\exist").Wait());
        }
    }
}