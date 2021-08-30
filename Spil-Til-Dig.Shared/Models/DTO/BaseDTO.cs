using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.DTO
{
    public abstract class BaseDTO<IdType>
    {
        public IdType Id { get; set; }
    }
}
