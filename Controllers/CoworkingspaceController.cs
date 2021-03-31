using CoworkingspaceAPI.Context;
using CoworkingspaceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoworkingspaceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoworkingspaceController : ControllerBase
    {
        private readonly ILogger<CoworkingspaceController> _logger;

        private CoworkingspaceContext _context;

        public CoworkingspaceController(ILogger<CoworkingspaceController> logger, CoworkingspaceContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /Coworkingspace
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coworkingspace>>> Get()
        {
            var result = new List<Coworkingspace>();
            try
            {
                result = await _context.Coworkingspace.ToListAsync();
            }
            catch
            {
                _logger.LogError("コワーキングスペース情報を取得できませんでした。");
            }

            return result;

        }
    }
}
