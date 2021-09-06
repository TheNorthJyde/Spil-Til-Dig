using Spil_Til_Dig.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public class GenreService : IGenreService
    {
        private HttpClient client;

        public GenreService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<GenreDTO>> GetAllGenres()
        {
            try
            {
                var test = await client.GetFromJsonAsync<List<GenreDTO>>("genre");
                return test;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
