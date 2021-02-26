using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalService.Models;

namespace SpringFestivalService.Services
{
    public interface IShowService
    {
        Task<Show> CreateAsync(Show show);
        Task<List<Show>> CreateShowListAsync();
        Task<Show> UpdateAsync(Show show);
        Task DeleteAsync(Show show);
    }
}