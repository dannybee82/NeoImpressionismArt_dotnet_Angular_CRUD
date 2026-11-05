using Application.DataTransferObjects;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ArtistMapper
    {

        public static ArtistDto ToDto(Artist entity)
        {
            ArtistDto dto = new();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
            dto.YearOfBirth = entity.YearOfBirth;
            dto.YearOfDeath = entity.YearOfDeath;

            return dto;
        }

    }
}
