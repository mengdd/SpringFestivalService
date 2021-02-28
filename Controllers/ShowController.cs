using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpringFestivalService.Models;
using SpringFestivalService.Services;

namespace SpringFestivalService.Controllers
{
    [ApiController]
    [Route("show")]
    public class ShowController : ControllerBase
    {
        private readonly ILogger<ShowController> _logger;
        private readonly IShowService _service;

        public ShowController(ILogger<ShowController> logger, IShowService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Show>>> GetShowsList()
        {
            return await _service.GetShowListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow([FromRoute] string id)
        {
            var student = await _service.GetShow(id);
            if (student == null)
            {
                return NotFound();
            }

            return student.FirstOrDefault();
        }
        [HttpPost]
        public async Task<ActionResult<Show>> CreateShow(Show show)
        {
            await _service.CreateAsync(show);

            return CreatedAtAction(nameof(GetShow), new {id = show.Id}, show);
        }
    }
}