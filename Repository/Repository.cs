using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using SpringFestivalService.Models;

namespace SpringFestivalService.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : BaseModel
    {
        private readonly ILogger<Repository<TModel>> _logger;
        private readonly IDynamoDBContext _context;

        public Repository(ILogger<Repository<TModel>> logger, IDynamoDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<TModel> CreateAsync(TModel model)
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

        public async Task<List<TModel>> GetListAsync(string primaryKey)
        {
            try
            {
                var list = await _context.QueryAsync<TModel>(primaryKey).GetRemainingAsync();
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<TModel> UpdateAsync(TModel model)
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

        public async Task DeleteAsync(TModel model)
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