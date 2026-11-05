using Domain.Entities;
using Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IArtworkRepository
    {
        IQueryable<Artwork> GetQueryable();

        Task<PaginatedList<Artwork>> GetPaginatedList(IQueryable<Artwork> query, int pageNumber, int pageSize);

        Task<Artwork?> GetById(int id);

        Task<Artwork?> GetByIdWithoutIncludes(int id);

        Task<Artwork> Create(Artwork entity);

        Task<Artwork> Update(Artwork entity);

        Task Delete(int id);
    }
}
