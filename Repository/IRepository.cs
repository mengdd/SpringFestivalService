using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalService.Models;

namespace SpringFestivalService.Repository
{
    public interface IRepository<Model> where Model : BaseModel
    {
        Task<Model> CreateAsync(Model model);
        Task<List<Model>> GetListAsync(string primaryKey);
        Task<Model> UpdateAsync(Model model);
        Task DeleteAsync(Model model);
    }
}