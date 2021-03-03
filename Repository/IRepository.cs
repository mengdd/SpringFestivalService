using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalService.Models;

namespace SpringFestivalService.Repository
{
    public interface IRepository<TModel> where TModel : BaseModel
    {
        Task<TModel> CreateAsync(TModel model);
        Task<List<TModel>> GetListAsync(string primaryKey);
        Task<TModel> UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
    }
}