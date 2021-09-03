using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class Item
    {
        public string name { get; set; }
        public string category { get; set; } = "DIGITAL_GOODS";
        public Money unit_amount { get; set; }
        public int quantity { get; set; } = 1;
        public string sku { get; set; }
    }
}
