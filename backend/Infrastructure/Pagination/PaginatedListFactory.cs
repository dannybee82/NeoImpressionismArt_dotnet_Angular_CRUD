using Domain.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Pagination
{
    public static class PaginatedListFactory
    {
        public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int currentPage, int pageSize)
        {
            var count = await source.CountAsync();

            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, "Id");
            var propAsObject = Expression.Convert(property, typeof(object));

            source = source.Skip((currentPage - 1) * pageSize).Take(pageSize);

            var items = await source.ToListAsync();

            return new PaginatedList<T>(items, count, currentPage, pageSize);
        }
    }
}
