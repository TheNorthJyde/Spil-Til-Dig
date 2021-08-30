using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public interface IGenreSerivce
    {
        Task<List<Genre>> GetAllGernres();
        Task AddGenreFromCMS(List<Genre> genres);
        Task DeleteGenreFromCMS(long id);
    }
}
