using Spil_Til_Dig.Shared.Entities;
using Spil_Til_Dig.Shared.Models.DTO;
using Spil_Til_Dig.Shared.Models.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Backend.Services
{
    public interface IPayPalService
    {
        Task<PayPalOrderCreated> CreateOrder(List<Product> products, string userId);
        Task<CaptureCompletedDTO> CaptureOrder(string orderNumber);
    }
}
