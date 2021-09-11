using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.DTO
{
    public class OrderDTO : BaseDTO<string>
    {
        public string InvoiceId { get; set; }
        public List<ProductKeyDTO> Keys { get; set; }
        public string UserId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
