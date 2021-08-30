using IGDB;
using IGDB.Models;
using Microsoft.Extensions.Options;
using Spil_Til_Dig.Backend.Database;
using Spil_Til_Dig.Backend.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e = Spil_Til_Dig.Shared.Entities;


namespace Spil_Til_Dig.Backend.Services.Seed
{
    public class SeedService : ISeedService
    {
        private IGDBClient igdb;
        private readonly IOptions<IGDBOptions> options;
        private readonly DatabaseContext Context;
        public SeedService(IOptions<IGDBOptions> options, DatabaseContext context)
        {
            this.options = options;
            igdb = new IGDBClient(options.Value.ClientId, options.Value.ClientSecret);
            Context = context;
        }

        public async Task Seed100Games()
        {
            var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, "fields id,name,summary, cover.*, genres.*, genres, first_release_date, involved_companies.company.name, involved_companies.*; limit 100; where platforms.id = 6 & category = 0 & summary != null & (involved_companies.publisher = true | involved_companies.developer = true);");
            var rng = new Random();
            
            foreach (var game in games)
            {
                var product = new e.Product();
                product.Genres = new List<e.Genre>();
                product.Keys = new List<e.ProduktKey>();

                product.Id = game.Id.Value;
                product.Name = game.Name;
                product.Developer = game.InvolvedCompanies.Values.FirstOrDefault(x => x.Developer.Value).Company.Value.Name ?? game.InvolvedCompanies.Values.FirstOrDefault(x => x.Publisher.Value).Company.Value.Name;
                product.Publicher = game.InvolvedCompanies.Values.FirstOrDefault(x => x.Publisher.Value).Company.Value.Name;
                foreach (var genre in game.Genres.Values)
                {
                    product.Genres.Add(Context.Genres.Find(genre.Id) ?? new e.Genre { Id = genre.Id.Value, Name = genre.Name });
                }
                //product.Genres.AddRange(game.Genres.Values.Select(x => new e.Genre { Id = x.Id.Value, Name = x.Name }));
                product.ImageUrl = "https:" + ImageHelper.GetImageUrl(game.Cover.Value.ImageId, size: ImageSize.Thumb);
                product.Price = rng.Next(15, 400);
                product.ReleaseDate = game.FirstReleaseDate.Value.DateTime;
                product.Summary = game.Summary;
                var ProduktKeyAmount = rng.Next(5, 50);
                for (int i = 0; i < ProduktKeyAmount; i++)
                {
                    product.Keys.Add(new e.ProduktKey(Guid.NewGuid().ToString()));
                }

                Context.Products.Add(product);
            }
            await Context.SaveChangesAsync();
        }
    }
}
