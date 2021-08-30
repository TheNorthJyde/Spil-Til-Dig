using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.DTO
{
    
    public class ProductDTO : BaseDTO<long>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsOnSale { get; set; }
        public decimal SalePrice { get; set; }
        public int KeyCount { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publicher { get; set; }
    }
}
