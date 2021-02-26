using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using SpringFestivalService.Models;

namespace SpringFestivalService.Repository
{
    public class Repository<Model> : IRepository<Model> where Model : BaseModel
    {
        private readonly ILogger<Repository<Model>> _logger;
        private readonly IDynamoDBContext _context;

        public Repository(ILogger<Repository<Model>> logger, IDynamoDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Model> CreateAsync(Model model)
        {
            try
            {
                await _context.SaveAsync(model);
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Model>> GetListAsync(string primaryKey)
        {
            try
            {
                var list = await _context.QueryAsync<Model>(primaryKey).GetRemainingAsync();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Model> UpdateAsync(Model model)
        {
            try
            {
                await _context.SaveAsync(model);
                return model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task DeleteAsync(Model model)
        {
            try
            {
                await _context.DeleteAsync(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}