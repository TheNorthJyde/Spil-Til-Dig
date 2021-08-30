using Spil_Til_Dig.Backend.Database;
using Spil_Til_Dig.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Repos
{
    public class GenreRepo : Repo<Genre, long>, IGenreRepo
    {
        public GenreRepo(DatabaseContext context) : base(context)
        {
        }
    }
}
