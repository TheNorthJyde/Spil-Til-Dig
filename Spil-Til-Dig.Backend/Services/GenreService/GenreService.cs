using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Backend.Repos;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public class GenreService : IGenreSerivce
    {
        private readonly IGenreRepo genreRepo;

        public GenreService(IGenreRepo genreRepo)
        {
            this.genreRepo = genreRepo;
        }

        public async Task AddGenreFromCMS(List<Genre> genres)
        {
            await genreRepo.AddRangeAsync(genres);
            await genreRepo.SaveAsync();
        }

        public async Task DeleteGenreFromCMS(long id)
        {
            var genre = await genreRepo.FindAsync(x => x.Id == id);
            if (genre != null)
            {
                genreRepo.Remove(genre);
            }
            await genreRepo.SaveAsync();
        }

        public async Task<List<Genre>> GetAllGernres()
        {
            return await genreRepo.GetAll().ToListAsync();
        }
    }
}
