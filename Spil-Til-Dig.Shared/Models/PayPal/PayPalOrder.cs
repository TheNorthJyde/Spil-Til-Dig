using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class PayPalOrder
    {
        public string intent { get; set; } = "CAPTURE";
        public List<PurchaseUnit> purchase_units { get; set; }
        public PayPalOrder()
        {
            purchase_units = new List<PurchaseUnit>();
        }
    }
}
