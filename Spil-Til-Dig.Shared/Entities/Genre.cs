using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Entities
{
    public class Genre : BaseEntity<long>
    {
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
