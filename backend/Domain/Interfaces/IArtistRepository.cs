using Domain.Entities;
using Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IArtistRepository
    {
        IQueryable<Artist> GetQueryable();

        Task<List<Artist>> GetAll();

        Task<PaginatedList<Artist>> GetPaginatedList(IQueryable<Artist> query, int pageNumber, int pageSize);

        Task<Artist?> GetById(int id);

        Task<Artist> Create(Artist entity);

        Task<Artist> Update(Artist entity);

        Task Delete(int id);
    }
}
