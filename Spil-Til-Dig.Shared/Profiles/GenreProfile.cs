using AutoMapper;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
