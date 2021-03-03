using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpringFestivalService.Configuration;
using SpringFestivalService.Models;
using SpringFestivalService.Repository;

namespace SpringFestivalService.Services
{
    public class VoteService : IVoteService
    {
        private readonly ILogger<ShowService> _logger;
        private readonly IRepository<Show> _repository;

        public VoteService(ILogger<ShowService> logger, IRepository<Show> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<List<Show>> Vote(Show show)
        {
            //TODO Refactor this part
            var allData = _repository.GetListAsync(Constants.Year).Result;
            var oldShow = allData.Where(s => s.Id.Equals(show.Id)).ToList().FirstOrDefault();
            if (oldShow != null)
            {
                var newVote = oldShow.Vote + 1;
                show.Vote = newVote;
                await _repository.UpdateAsync(show);
            }

            return _repository.GetListAsync(Constants.Year).Result;
        }
    }
}