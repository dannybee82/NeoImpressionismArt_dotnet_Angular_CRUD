using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData.Configurations
{
    public class ArtImageConfiguration : IEntityTypeConfiguration<ArtImage>
    {
        public void Configure(EntityTypeBuilder<ArtImage> builder)
        {
            builder.HasData(
                new ArtImage()
                {
                    Id = 1,
                    ContentType = "image/png",
                    Image = SeedDataLoader.LoadImage("001.png")
                },
                new ArtImage()
                {
                    Id = 2,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("002.jpeg")
                },
                new ArtImage()
                {
                    Id = 3,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("003.jpeg")
                },
                new ArtImage()
                {
                    Id = 4,
                    ContentType = "image/jpg",
                    Image = SeedDataLoader.LoadImage("004.jpg")
                },
                new ArtImage()
                {
                    Id = 5,
                    ContentType = "image/jpg",
                    Image = SeedDataLoader.LoadImage("005.jpg")
                },
                new ArtImage()
                {
                    Id = 6,
                    ContentType = "image/jpg",
                    Image = SeedDataLoader.LoadImage("006.jpg")
                },
                new ArtImage()
                {
                    Id = 7,
                    ContentType = "image/jpg",
                    Image = SeedDataLoader.LoadImage("007.jpg")
                },
                new ArtImage()
                {
                    Id = 8,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("008.jpeg")
                },
                new ArtImage()
                {
                    Id = 9,
                    ContentType = "image/png",
                    Image = SeedDataLoader.LoadImage("009.png")
                },
                new ArtImage()
                {
                    Id = 10,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("010.jpeg")
                },
                new ArtImage()
                {
                    Id = 11,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("011.jpeg")
                },
                new ArtImage()
                {
                    Id = 12,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("012.jpeg")
                },
                new ArtImage()
                {
                    Id = 13,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("013.jpeg")
                },
                new ArtImage()
                {
                    Id = 14,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("014.jpeg")
                },
                new ArtImage()
                {
                    Id = 15,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("015.jpeg")
                },
                new ArtImage()
                {
                    Id = 16,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("016.jpeg")
                },
                new ArtImage()
                {
                    Id = 17,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("017.jpeg")
                },
                new ArtImage()
                {
                    Id = 18,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("018.jpeg")
                },
                new ArtImage()
                {
                    Id = 19,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("019.jpeg")
                },
                new ArtImage()
                {
                    Id = 20,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("020.jpeg")
                },
                new ArtImage()
                {
                    Id = 21,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("021.jpeg")
                },
                new ArtImage()
                {
                    Id = 22,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("022.jpeg")
                },
                new ArtImage()
                {
                    Id = 23,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("023.jpeg")
                },
                new ArtImage()
                {
                    Id = 24,
                    ContentType = "image/png",
                    Image = SeedDataLoader.LoadImage("024.png")
                },
                new ArtImage()
                {
                    Id = 25,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("025.jpeg")
                },
                new ArtImage()
                {
                    Id = 26,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("026.jpeg")
                },
                new ArtImage()
                {
                    Id = 27,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("027.jpeg")
                },
                new ArtImage()
                {
                    Id = 28,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("028.jpeg")
                },
                new ArtImage()
                {
                    Id = 29,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("029.jpeg")
                },
                new ArtImage()
                {
                    Id = 30,
                    ContentType = "image/png",
                    Image = SeedDataLoader.LoadImage("030.png")
                },
                new ArtImage()
                {
                    Id = 31,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("031.jpeg")
                },
                new ArtImage()
                {
                    Id = 32,
                    ContentType = "image/jpeg",
                    Image = SeedDataLoader.LoadImage("032.jpeg")
                }
            );
        }
    }
}
