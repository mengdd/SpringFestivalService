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
    public class ShowService : IShowService
    {
        private readonly ILogger<ShowService> _logger;
        private readonly IRepository<Show> _repository;

        public ShowService(
            ILogger<ShowService> logger,
            IRepository<Show> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<Show> CreateAsync(Show show)
        {
            try
            {
                show.Year = Constants.Year;
                var createdShow = await _repository.CreateAsync(show);
                return createdShow;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        public async Task<List<Show>> GetShowListAsync()
        {
            try
            {
                var showsList = await _repository.GetListAsync(Constants.Year);
                return showsList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        public async Task<List<Show>> GetShow(string id)
        {
            try
            {
                var showsList = await _repository.GetListAsync(id);
                return showsList;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }


        public async Task<Show> UpdateAsync(Show show)
        {
            try
            {
                var updatedShow = await _repository.UpdateAsync(show);
                return updatedShow;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                var model = await _repository.GetListAsync(id);
                await _repository.DeleteAsync(model.FirstOrDefault());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}