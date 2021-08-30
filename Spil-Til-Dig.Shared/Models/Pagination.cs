using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models
{
    public class Pagination
    {
        public string Search { get; set; }
        public int PageSize { get; set; } = 12;
        public int currentPage { get; set; } = 1;

        public int MaxPrice { get; set; }

        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
