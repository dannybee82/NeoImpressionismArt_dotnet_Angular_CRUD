using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Artworks", Schema = "NeoImpressionismArt")]
    public class Artwork
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [ForeignKey("Artist")]
        public int? ArtistId { get; set; }

        public Artist? Artist { get; set; }


        [ForeignKey("ArtImage")]
        public int? ArtImageId { get; set; }

        public ArtImage? ArtImage { get; set; }
    }
}
