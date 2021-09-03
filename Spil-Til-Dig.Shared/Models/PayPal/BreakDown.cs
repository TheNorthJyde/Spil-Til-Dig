using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class BreakDown
    {
        public Money item_total { get; set; }
        public Money discount { get; set; }
        public Money tax_total { get; set; }
    }
}
