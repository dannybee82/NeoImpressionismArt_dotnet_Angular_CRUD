using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    [Table("ArtImages", Schema = "NeoImpressionismArt")]
    public class ArtImage
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Image { get; set; }
    }
}
