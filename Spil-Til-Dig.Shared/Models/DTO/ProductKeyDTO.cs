using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.DTO
{
    public class ProductKeyDTO : BaseDTO<string>
    {
        public ProductDTO Product { get; set; }
    }
}
