using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ArtImageRepository : IArtImageRepository
    {
        private readonly AppDbContext _dbContext;

        public ArtImageRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateAndReturnId(ArtImage entity)
        {
            // Somehow a new issue at this point.
            int nextId = await _dbContext.ArtImages.MaxAsync(x => x.Id);
            entity.Id = nextId + 1;

            await _dbContext.ArtImages.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.ArtImages.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ArtImage?> GetById(int id)
        {
            return await _dbContext.ArtImages
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task Update(ArtImage entity)
        {
            _dbContext.ArtImages.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

    }

}