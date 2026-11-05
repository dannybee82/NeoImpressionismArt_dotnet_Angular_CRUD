using Application.DataTransferObjects;
using Application.Mappers;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<List<ArtistDto>> GetAll()
        {
            var items = await _artistRepository.GetAll();
            return items.Select(x => ArtistMapper.ToDto(x)).ToList();
        }
    }
}
