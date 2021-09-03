using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class PurchaseUnit
    {
        public AmountWithBreakdown amount { get; set; }
        public string description { get; set; }
        public string soft_descriptor { get; set; } = "Spil-Til-Dig Køb";
        public List<Item> items { get; set; }
        public string invoice_id { get; set; }

        public PurchaseUnit()
        {
            items = new List<Item>();
        }
    }
}
