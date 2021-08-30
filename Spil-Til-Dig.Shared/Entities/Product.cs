using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Entities
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public List<Genre> Genres { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsOnSale { get; set; }
        public decimal SalePrice { get; set; }
        public List<ProduktKey> Keys { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publicher { get; set; }
    }
}
