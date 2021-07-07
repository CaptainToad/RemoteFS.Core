using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        [HttpGet("{path}")]
        public IEnumerable<FileSystemObjectModel> Get(string path)
        {
            var decodedPath = HttpUtility.UrlDecode(path);

            return _fileSystem.GetFileSystemObjects(decodedPath);
        }
    }
}
