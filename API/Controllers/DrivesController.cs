using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Models;
using API.Services;
using System.Web;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrivesController : ControllerBase
    {
        private readonly ILogger<DrivesController> _logger;
        private readonly FileSystem _fileSystem;

        public DrivesController(ILogger<DrivesController> logger, FileSystem fileSystem)
        {
            _logger = logger;
            _fileSystem = fileSystem;
        }

        [HttpGet]
        public IEnumerable<Drive> Get()
        {
            return _fileSystem.GetDrives();
        }

        // GET api/Drives/C%3A%5C OR api/Drives/C:/ OR api/Drives/C
        // The drive name should be URL encoded
        [HttpGet("{name}")]
        public ActionResult<Drive> Get(string name)
        {
            var driveRequested = HttpUtility.UrlDecode(name);
            var drive = _fileSystem.GetDrive(driveRequested);

            return drive;
        }
    }
}
