using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class SellerReceivableBreakdown
    {
        public Money gross_amount { get; set; }
        public Money paypal_fee { get; set; }
        public Money net_amount { get; set; }
    }
}
