using Spil_Til_Dig.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public interface IGenreService
    {
        Task<List<GenreDTO>> GetAllGenres();
    }
}
