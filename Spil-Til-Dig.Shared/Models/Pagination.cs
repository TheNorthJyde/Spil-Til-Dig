using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spil_Til_Dig.Shared.Models
{
    public class Pagination
    {
        public int PageSize { get; set; } = 20;
        public int CurrentPage { get; set; } = 1;

        public string Search { get; set; }
        public long GenreId { get; set; }
        public int MaxPrice { get; set; }
        public bool IsOnSale { get; set; }

        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public string AsQuery()
        {
            string query = "?";
            if (PageSize > 0)
            {
                query += "pageSize=" + PageSize + "&";
            }
            if (CurrentPage > 0)
            {
                query += "currentPage=" + CurrentPage + "&";
            }
            if (!string.IsNullOrEmpty(Search))
            {
                query += "Search=" + Search + "&";
            }
            if (GenreId != 0)
            {
                query += "GenreId=" + GenreId + "&";
            }
            if (MaxPrice != 0)
            {
                query += "MaxPrice=" + MaxPrice + "&";
            }
            if (IsOnSale)
            {
                query += "IsOnSale=" + IsOnSale;
            }
            return query;
        }

        public void PreparePaging()
        {
            if (!string.IsNullOrWhiteSpace(Search))
            {
                Search = Search.ToLower().Trim();
            }
            CurrentPage = CurrentPage != 0 ? CurrentPage : 1;
            PageSize = PageSize < 100 ? PageSize : 100;
            PageSize = PageSize >= 0 ? PageSize : 12;
        }

        public Pagination()
        {

        }
        public Pagination(int pageSize)
        {
            this.PageSize = pageSize;
        }
    }
}
