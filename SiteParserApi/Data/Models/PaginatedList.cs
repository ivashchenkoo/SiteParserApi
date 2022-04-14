using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteParserApi.Data.Models
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public int? NextPage
        {
            get
            {
                return PageIndex < TotalPages ? (int?)(PageIndex + 1) : null;
            }
        }

        public int? PreviousPage
        {
            get
            {
                return PageIndex > 0 ? (int?)(PageIndex - 1) : null;
            }
        }

        public List<T> Items { get; set; }

        public PaginatedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            Items = new List<T>();
            Items.AddRange(source.Skip((PageIndex > 0 ? PageIndex - 1 : PageIndex) * PageSize).Take(PageSize));
        }
    }
}
