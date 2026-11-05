using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasData(
                new Artist()
                {
                    Id = 1,
                    Name = "Dolores Abernathy",
                    Description = "This artist's mysterious background is reflected in her enigmatic paintings, where colorful strokes meet photographic detail. Each piece tells a rich story, balancing playful creativity with profound depth.",
                    YearOfBirth = 1987,
                    YearOfDeath = null
                },
                new Artist()
                {
                    Id = 2,
                    Name = "Elena Marchetti",
                    Description = "A luminous colorist who builds her canvases from small, deliberate dabs of pure pigment. Her scenes of Mediterranean colors and use of sunlight shimmer with vibrant contrasts.",
                    YearOfBirth = 1986,
                    YearOfDeath = null
                },
                new Artist()
                {
                    Id = 3,
                    Name = "Théodore Blanchard",
                    Description = "A methodical painter who applies Abernathy's a special technique to his paintings. His artworks balance structured geometry with soft, atmospheric light.",
                    YearOfBirth = 1987,
                    YearOfDeath = null
                },
                new Artist()
                {
                    Id = 4,
                    Name = "Yuki Nakamura",
                    Description = "A poetic draftsman of color who blends the Neo Impressionist style with delicate compositions. Her artworks of women in blossoming orchids and misty coastlines feel serene and airy.",
                    YearOfBirth = 1986,
                    YearOfDeath = null
                }
            );
        }
    }
}
