using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.PayPal
{
    public class Money
    {
        public string currency_code { get; set; }
        public decimal value { get; set; }
    }
}
