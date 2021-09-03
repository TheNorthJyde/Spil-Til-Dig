using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Pages
{
    public partial class Index
    {
        private string _authMessage;
        private string _surnameMessage;
        private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private async Task GetClaimsPrincipalData()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                _authMessage = $"{user.Identity.Name} is authenticated.";
                _claims = user.Claims;
                _surnameMessage =
                    $"Surname: {user.FindFirst(c => c.Type == ClaimTypes.Surname)?.Value}";
            }
            else
            {
                _authMessage = "The user is NOT authenticated.";
            }
        }
    }
}
