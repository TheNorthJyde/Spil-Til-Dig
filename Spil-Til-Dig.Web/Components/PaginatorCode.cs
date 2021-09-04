using MatBlazor;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Web.Components
{
    public class PaginatorCode : BaseMatPaginator
    {
        [Parameter]
        public bool Disabled { get; set; } = false;
    }
}
