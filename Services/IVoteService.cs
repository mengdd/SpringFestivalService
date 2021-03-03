using System.Collections.Generic;
using System.Threading.Tasks;
using SpringFestivalService.Models;

namespace SpringFestivalService.Services
{
    public interface IVoteService
    {
        Task<List<Show>> Vote(Show show);
    }
}