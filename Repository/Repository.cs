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
                _logger.LogError(e.ToString());
                throw;
            }
        }

        public async Task<List<TModel>> GetListAsync(string primaryKey, string indexName = null)
        {
            var dynamoDbOperationConfig = new DynamoDBOperationConfig
            {
                IndexName = indexName
            };
            try
            {
                var list = await _context.QueryAsync<TModel>(primaryKey, dynamoDbOperationConfig).GetRemainingAsync();
                return list;
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
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
                _logger.LogError(e.ToString());
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
                _logger.LogError(e.ToString());
                throw;
            }
        }
    }
}