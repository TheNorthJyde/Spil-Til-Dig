using Spil_Til_Dig.Shared.Models.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models.DTO
{
    public class CaptureCompletedDTO
    {
        public PaypalCapureComplete CompleteCaputre { get; set; }
        public List<ProductKeyDTO> Keys { get; set; }
    }
}
