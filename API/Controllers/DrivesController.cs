﻿using API.Models;
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
    public class DrivesController : ControllerBase
    {
        private readonly ILogger<DrivesController> _logger;
        private readonly IFileSystemService _fileSystem;

        public DrivesController(ILogger<DrivesController> logger, IFileSystemService fileSystem)
        {
            _logger = logger;
            _fileSystem = fileSystem;

            _logger.LogInformation($"Created {nameof(DrivesController)} controller");
        }

        [HttpGet]
        public async Task<IEnumerable<DriveModel>> Get()
        {
            return await _fileSystem.GetDrives();
        }

        // GET api/Drives/C%3A%5C OR api/Drives/C:/ OR api/Drives/C
        // The drive name should be URL encoded
        [HttpGet("{name}")]
        public async Task<ActionResult<DriveModel>> Get(string name)
        {
            var driveRequested = HttpUtility.UrlDecode(name);
            _logger.LogInformation($"Getting drive: {driveRequested}");

            var drive = await _fileSystem.GetDrive(driveRequested);

            return drive;
        }
    }
}
