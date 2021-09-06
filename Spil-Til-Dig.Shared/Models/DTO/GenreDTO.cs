using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.DTO
{
    public class GenreDTO : BaseDTO<long>
    {
        public string Name { get; set; }


        public static implicit operator long(GenreDTO g) => g.Id;
    }
}
