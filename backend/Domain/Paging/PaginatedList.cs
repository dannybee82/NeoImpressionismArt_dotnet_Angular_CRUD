using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Paging
{
    public class PaginatedList<T>
    {
        public int CurrentPage { get; set; }
        public int From { get; set; }
        public List<T> Items { get; set; }
        public int PageSize { get; set; }
        public int To { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
            set { }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
            set { }
        }

        public PaginatedList(List<T> items, int count, int currentPage, int pageSize)
        {
            Items = items;
            TotalCount = count;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            From = TotalCount == 0 ? 0 : (currentPage - 1) * pageSize + 1;
            To = Math.Min(currentPage * pageSize, TotalCount);
            HasPreviousPage = (CurrentPage > 1);
            HasNextPage = (CurrentPage < TotalPages);
        }
    }
}
