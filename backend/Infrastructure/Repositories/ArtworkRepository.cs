using Domain.Entities;
using Domain.Interfaces;
using Domain.Paging;
using Infrastructure.Context;
using Infrastructure.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ArtworkRepository : IArtworkRepository
    {
        private readonly AppDbContext _dbContext;

        public ArtworkRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Artwork> Create(Artwork entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.Artworks.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Artwork?> GetById(int id)
        {
            return await _dbContext.Artworks
                .AsNoTracking()
                .Include(x => x.Artist)
                .Include(x => x.ArtImage)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<Artwork?> GetByIdWithoutIncludes(int id)
        {
            return await _dbContext.Artworks
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<PaginatedList<Artwork>> GetPaginatedList(IQueryable<Artwork> query, int pageNumber, int pageSize)
        {
            return await PaginatedListFactory.CreateAsync(query, pageNumber, pageSize);
        }

        public IQueryable<Artwork> GetQueryable()
        {
            return _dbContext.Artworks
                .AsNoTracking()
                .Include(x => x.Artist)
                .Include(x => x.ArtImage);
        }

        public async Task<Artwork> Update(Artwork entity)
        {
            _dbContext.Artworks.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
