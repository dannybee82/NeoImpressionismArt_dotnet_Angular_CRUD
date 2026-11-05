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
    public class ArtistRepository : IArtistRepository
    {
        private readonly AppDbContext _dbContext;

        public ArtistRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Artist> Create(Artist entity)
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
                _dbContext.Artists.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Artist>> GetAll()
        {
            return await _dbContext.Artists.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Artist?> GetById(int id)
        {
            return await _dbContext.Artists
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task<PaginatedList<Artist>> GetPaginatedList(IQueryable<Artist> query, int pageNumber, int pageSize)
        {
            return await PaginatedListFactory.CreateAsync(query, pageNumber, pageSize);
        }

        public IQueryable<Artist> GetQueryable()
        {
            return _dbContext.Artists
                .AsNoTracking();
        }

        public async Task<Artist> Update(Artist entity)
        {
            _dbContext.Artists.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }

}