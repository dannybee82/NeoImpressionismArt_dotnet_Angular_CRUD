using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class SeedImages
    {
        private static List<ArtImage> images = new List<ArtImage>()
        {
            new ArtImage()
            {
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("001.png")
             },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("002.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("003.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("004.jpg")
            },
            new ArtImage()
            {
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("005.jpg")
            },
            new ArtImage()
            {
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("006.jpg")
            },
            new ArtImage()
            {
                ContentType = "image/jpg",
                Image = SeedDataLoader.LoadImage("007.jpg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("008.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("009.png")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("010.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("011.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("012.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("013.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("014.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("015.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("016.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("017.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("018.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("019.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("020.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("021.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("022.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("023.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("024.png")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("025.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("026.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("027.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("028.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("029.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/png",
                Image = SeedDataLoader.LoadImage("030.png")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("031.jpeg")
            },
            new ArtImage()
            {
                ContentType = "image/jpeg",
                Image = SeedDataLoader.LoadImage("032.jpeg")
            }
        };

        public static async Task SeedAsync(AppDbContext db)
        {
            int count = await db.ArtImages.Select(x => x.Id).CountAsync();

            if (count == 0)
            {
                // Traverse Artworks and set ArtImage Id's.
                var artworks = await db.Artworks.ToListAsync();

                if(artworks.Count() == images.Count())
                {
                    for (int i = 0; i < artworks.Count(); i++)
                    {
                        var image = images[i];
                        artworks[i].ArtImage = image;
                        db.Artworks.Update(artworks[i]);
                        await db.SaveChangesAsync();
                    }
                }                               
            }
        }

    }
}
