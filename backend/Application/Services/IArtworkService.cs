using Application.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IArtworkService
    {

        Task<PaginatedListDto<ArtworkDto>> GetPagedList(int pageNumber, int pageSize);

        Task<ArtworkDto> GetById(int id);

        Task Create(IFormFile file, CreateOrUpdateArtworkDto dto);

        Task Update(IFormFile? file, CreateOrUpdateArtworkDto dto);

        Task Delete(int id);

        Task<ArtImage?> GetImage(int id);

    }
}
