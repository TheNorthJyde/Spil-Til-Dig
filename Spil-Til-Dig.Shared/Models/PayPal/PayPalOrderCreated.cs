using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class PayPalOrderCreated
    {
        public string id { get; set; }
        public string status { get; set; }
        public List<Link> links { get; set; }
    }
}
