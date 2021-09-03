using AutoMapper;
using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ForMember(d => d.KeyCount, s => s.MapFrom(k => k.Keys.Count)).ReverseMap();
            CreateMap<ProduktKey, ProductKeyDTO>().ReverseMap();
            //CreateMap(typeof(PagedList<>), typeof(PagedList<>));
            //CreateMap<PagedList<Product>, PagedList<ProductDTO>>();
            //CreateMap<List<Product>, List<ProductDTO>>();
        }
    }
}
