using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Entities
{
    [Index(nameof(IsSold))]
    public class ProduktKey : BaseEntity<string>
    {
        public bool IsSold { get; set; }
        public long? ProductId { get; set; }
        public Product Product { get; set; }
        public ProduktKey()
        {

        }
        public ProduktKey(string key)
        {
            this.Id = key;
        }
    }
}
