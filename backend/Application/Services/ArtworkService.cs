using Application.DataTransferObjects;
using Application.Mappers;
using Application.Settings;
using Domain.Entities;
using Domain.Interfaces;
using FileSignatures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _artworkRepository;
        private readonly IArtImageRepository _artImageRepository;
        private readonly IFileFormatInspector _fileFormatInspector;
        private readonly IAllowedFileFormatList _allowedFileFormatList;

        public ArtworkService(
            IArtworkRepository artworkRepository, 
            IArtImageRepository artImageRepository,
            IFileFormatInspector fileFormatInspector,
            IAllowedFileFormatList allowedFileFormatList
        )
        {
            _artworkRepository = artworkRepository;
            _artImageRepository = artImageRepository;
            _fileFormatInspector = fileFormatInspector;
            _allowedFileFormatList = allowedFileFormatList;
        }

        public async Task Create(IFormFile file, CreateOrUpdateArtworkDto dto)
        {
            if (file == null)
            {
                throw new Exception("File is required");
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);

            var fileFormat = _fileFormatInspector.DetermineFileFormat(ms);
            string extension = Path.GetExtension(file.FileName).ToLower().Replace(".", "");

            if (fileFormat == null || string.IsNullOrEmpty(extension))
            {
                throw new Exception("Unable to determine fileformat or extension.");
            }

            var record = _allowedFileFormatList.AllowedFileList
                .SingleOrDefault(x =>
                    x.Extension.Equals(extension) &&
                    x.FileFormat.Any(y => y.GetType() == fileFormat.GetType()));

            if (record == null)
            {
                throw new Exception("Not allowed file format.");
            }

            var entity = ArtworkMapper.ToEntity(dto, ms.ToArray(), record.Extension);
            await _artworkRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _artworkRepository.Delete(id);
        }

        public async Task<ArtworkDto> GetById(int id)
        {
            var item = await _artworkRepository.GetById(id);

            if (item == null)
            {
                throw new Exception("Record not found");
            }

            return ArtworkMapper.ToDto(item);
        }

        public async Task<ArtImage?> GetImage(int id)
        {
            return await _artImageRepository.GetById(id);
        }

        public async Task<PaginatedListDto<ArtworkDto>> GetPagedList(int pageNumber, int pageSize)
        {
            var query = _artworkRepository.GetQueryable();
            bool isOrderingApplied = false;

            if (!isOrderingApplied)
            {
                query = query.OrderByDescending(x => x.Id);
            }

            var paginatedList = await _artworkRepository.GetPaginatedList(query, pageNumber, pageSize);
            return ArtworkMapper.ToPaginatedDto(paginatedList);
        }

        public async Task Update(IFormFile? file, CreateOrUpdateArtworkDto dto)
        {
            if (dto.Id == null)
            {
                throw new Exception("Can't update - there is no Id.");
            }

            var itemToUpdate = await _artworkRepository.GetByIdWithoutIncludes(dto.Id ?? 0);

            if (itemToUpdate == null)
            {
                throw new Exception("Can't update - record not found.");
            }

            // Update image when there is one.
            if(file != null)
            {
                using var ms = new MemoryStream();
                await file.CopyToAsync(ms);

                var fileFormat = _fileFormatInspector.DetermineFileFormat(ms);
                string extension = Path.GetExtension(file.FileName).ToLower().Replace(".", "");

                if (fileFormat == null || string.IsNullOrEmpty(extension))
                {
                    throw new Exception("Unable to determine fileformat or extension.");
                }

                var record = _allowedFileFormatList.AllowedFileList
                    .SingleOrDefault(x =>
                        x.Extension.Equals(extension) &&
                        x.FileFormat.Any(y => y.GetType() == fileFormat.GetType()));

                if (record == null)
                {
                    throw new Exception("Not allowed file format.");
                }

                var image = await _artImageRepository.GetById(itemToUpdate.ArtImageId ?? 0);

                if (image != null)
                {
                    image.ContentType = $"image/{extension}";
                    image.Image = ms.ToArray();

                    await _artImageRepository.Update(image);
                }
                else
                {
                    // Add new image.
                    itemToUpdate.ArtImage = new ArtImage()
                    {
                        ContentType = $"image/{extension}",
                        Image = ms.ToArray()
                    };
                }
            }

            // Update record: itemToUpdate
            itemToUpdate.Name = dto.Name;
            itemToUpdate.Description = dto.Description;
            itemToUpdate.ArtistId = dto.ArtistId;

            await _artworkRepository.Update(itemToUpdate);
        }

    }
}