using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileSystemObjectsController : ControllerBase
    {
        private readonly ILogger<DrivesController> _logger;
        private readonly IFileSystemService _fileSystem;

        public FileSystemObjectsController(ILogger<DrivesController> logger, IFileSystemService fileSystem)
        {
            _logger = logger;
            _fileSystem = fileSystem;

            _logger.LogInformation($"Created {nameof(FileSystemObjectsController)} controller");
        }

        [HttpGet("{path}")]
        public async Task<IEnumerable<FileSystemObjectModel>> Get(string path)
        {
            _logger.LogInformation($"Getting file system objects for path: {path}");

            var decodedPath = HttpUtility.UrlDecode(path);

            return await _fileSystem.GetFileSystemObjects(decodedPath);
        }
    }
}
