using API.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using System;
using System.Linq;

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
        public void GetDrives_NoParameters_ReturnsListOfDrives()
        {
            var drives = _FileSystemService.GetDrives();

            Assert.That(drives, Has.Count.GreaterThan(0));
        }

        [Test()]
        public void GetDrive_DriveC_ReturnsDrive()
        {
            var drive = _FileSystemService.GetDrive("C");

            Assert.That(drive, Has.Property("Name").EqualTo("C:\\"));
        }
    }
}