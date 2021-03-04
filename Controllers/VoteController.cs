using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpringFestivalService.Configuration;
using SpringFestivalService.Models;
using SpringFestivalService.Services;

namespace SpringFestivalService.Controllers
{
    [ApiController]
    [Route("vote")]
    public class VoteController : ControllerBase
    {
        private readonly ILogger<VoteController> _logger;
        private readonly IVoteService _service;

        public VoteController(IVoteService service, ILogger<VoteController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public async Task<List<Show>> Vote([FromBody] Show show)
        {
            var result = await _service.Vote(show.Id);

            return result;
        }
    }
}