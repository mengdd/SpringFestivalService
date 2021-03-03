using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalService.Models;

namespace SpringFestivalService.Services
{
    public interface IShowService
    {
        Task<Show> CreateAsync(Show show);
        Task<List<Show>> GetShowListAsync();
        Task<List<Show>> GetShow(string id);
        Task<Show> UpdateAsync(Show show);
        Task DeleteAsync(string id);
    }
}