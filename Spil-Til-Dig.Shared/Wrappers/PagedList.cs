using Spil_Til_Dig.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Spil_Til_Dig.Shared.Converters;

namespace Spil_Til_Dig.Shared.Wrappers
{
    [JsonConverter(typeof(PagedListJsonConverterFactory))]
    public class PagedList<T> : List<T>
    {
        public Pagination Paging { get; set; }
        public bool HasPrevious => (this.Paging.CurrentPage > 1);
        public bool HasNext => (this.Paging.CurrentPage < this.Paging.TotalPages);

        T[] Items
        {
            get
            {
                return this.ToArray();
            }
            set
            {
                if (value != null)
                {
                    this.AddRange(value);
                }
            }
        }
        public PagedList()
        {

        }
        public PagedList(List<T> items, Pagination pagination)
        {
            Paging = pagination;
            AddRange(items);
        }
        public static PagedList<T> Create(IQueryable<T> source, Pagination pagination)
        {
            pagination.TotalCount = source.Count();
            pagination.TotalPages = (int)Math.Ceiling(pagination.TotalCount / (double)pagination.PageSize);
            pagination.CurrentPage = pagination.CurrentPage <= pagination.TotalPages ? pagination.CurrentPage : pagination.TotalPages;
            var items = pagination.PageSize > 0 ? source.Skip((pagination.CurrentPage - 1) * pagination.PageSize).Take(pagination.PageSize).ToList() : source.ToList();
            return new PagedList<T>(items, pagination);
        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, Pagination pagination)
        {
            pagination.TotalCount = source.Count();
            pagination.TotalPages = (int)Math.Ceiling(pagination.TotalCount / (double)pagination.PageSize);
            pagination.CurrentPage = pagination.CurrentPage <= pagination.TotalPages ? pagination.CurrentPage : pagination.TotalPages != 0 ? pagination.TotalPages : 1;
            var items = pagination.PageSize > 0 ? await source.Skip((pagination.CurrentPage - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync() : await source.ToListAsync();
            return new PagedList<T>(items, pagination);
        }
    }
}
