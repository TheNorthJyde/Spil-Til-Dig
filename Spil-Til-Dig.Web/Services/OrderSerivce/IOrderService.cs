using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Models.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Services
{
    public interface IOrderService
    {
        Task<PayPalOrderCreated> CreateOrder(List<ProductDTO> products);
        Task<CaptureCompletedDTO> CaputreOrder(string orderNumber);
    }
}
