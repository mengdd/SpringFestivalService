using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Show>> Vote(string showId)
        {
            try
            {
                //TODO Refactor this part
                var allData = await _repository.GetListAsync(Constants.Year);
                var show = allData.Where(s => s.Id.Equals(showId)).ToList().FirstOrDefault();
                if (show != null)
                {
                    var newVote = show.Vote + 1;
                    show.Vote = newVote;
                    await _repository.UpdateAsync(show);
                }

                return _repository.GetListAsync(Constants.Year).Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}