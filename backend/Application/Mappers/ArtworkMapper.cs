using Application.DataTransferObjects;
using Domain.Entities;
using Domain.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ArtworkMapper
    {

        public static ArtworkDto ToDto(Artwork entity)
        {
            ArtworkDto dto = new();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;

            if(entity.Artist != null)
            {
                dto.Artist = ArtistMapper.ToDto(entity.Artist);
            }

            if(entity.ArtImageId != null)
            {
                dto.ImageId = entity.ArtImageId;
            }

            return dto;
        }

        public static PaginatedListDto<ArtworkDto> ToPaginatedDto(PaginatedList<Artwork> paginatedList)
        {
            return new PaginatedListDto<ArtworkDto>()
            {
                TotalCount = paginatedList.TotalCount,
                CurrentPage = paginatedList.CurrentPage,
                PageSize = paginatedList.PageSize,
                TotalPages = paginatedList.TotalPages,
                From = paginatedList.From,
                To = paginatedList.To,
                Items = paginatedList.Items.Select(x => ToDto(x)).ToList(),
                HasNextPage = paginatedList.HasNextPage,
                HasPreviousPage = paginatedList.HasPreviousPage
            };
        }

        public static Artwork ToEntity(CreateOrUpdateArtworkDto dto, byte[] image, string fileFormat)
        {
            Artwork entity = new();

            if (dto.Id != null)
            {
                entity.Id = dto.Id ?? 0;
            }
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.ArtistId = dto.ArtistId;

            entity.ArtImage = new ArtImage()
            {
                ContentType = $"image/{fileFormat}",
                Image = image
            };

            return entity;
        }

    }
}
