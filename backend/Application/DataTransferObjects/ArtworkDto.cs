using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class ArtworkDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ArtistDto? Artist { get; set; }

        public int? ImageId { get; set; }

    }
}
