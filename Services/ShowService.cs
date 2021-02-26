using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
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
                var createdShow = await _repository.CreateAsync(show);
                return createdShow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Show>> CreateShowListAsync()
        {
            try
            {
                var showsList = await _repository.GetListAsync("?"); //TODO do we need a primary key?
                return showsList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteAsync(Show show)
        {
            try
            {
                await _repository.DeleteAsync(show);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}