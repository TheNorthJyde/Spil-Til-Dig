using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Entities
{
    public class Order : BaseEntity<string>
    {
        public string InvoiceId { get; set; }
        public List<ProduktKey> Keys { get; set; }
        public string UserId { get; set; }
        public bool IsPaid { get; set; }
        public Order()
        {
            Keys = new List<ProduktKey>();
        }
    }
}
