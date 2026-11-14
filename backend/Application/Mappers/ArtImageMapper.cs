using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class ArtImageMapper
    {

        public static ArtImage ToEntity(byte[] image, string fileFormat)
        {
            return new ArtImage()
            {
                ContentType = $"image/{fileFormat}",
                Image = image
            };
        }

    }
}
