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
    public class ArtworkConfiguration : IEntityTypeConfiguration<Artwork>
    {
        public void Configure(EntityTypeBuilder<Artwork> builder)
        {
            builder.HasData(
                new Artwork() 
                { 
                    Id = 1,
                    Name = "The Swing Beneath the Canopy",
                    Description = "The painting shows a woman in a beautiful green and red dress, standing upright on a swing in the forest.",
                    ArtistId = 2,
                    ArtImageId = 1
                },
                new Artwork()
                {
                    Id = 2,
                    Name = "Harvest Reverie in the Vineyard",
                    Description = "The painting shows a beautiful woman with dark hair stands in the vineyard, lost in her own thoughts.",
                    ArtistId = 1,
                    ArtImageId = 2
                },
                new Artwork()
                {
                    Id = 3,
                    Name = "Guardian angel with a Candle",
                    Description = "The painting depicts a guardian angel with an aura, holding a candle in her hand.",
                    ArtistId = 3,
                    ArtImageId = 3
                },
                new Artwork()
                {
                    Id = 4,
                    Name = "The Magic Mirror",
                    Description = "The painting depicts an alluring woman standing in front of a mirror, accompanied by magical light effects.",
                    ArtistId = 4,
                    ArtImageId = 4
                },
                new Artwork()
                {
                    Id = 5,
                    Name = "A Quiet Hour in May",
                    Description = "The painting depicts a woman lying in a field of flowers on a sunny day in May.",
                    ArtistId = 2,
                    ArtImageId = 5
                },
                new Artwork()
                {
                    Id = 6,
                    Name = "Portrait of Éléonore de Valcour",
                    Description = "A portrait made by Dolores Abernathy showing the noblewoman Éléonore de Valcour.",
                    ArtistId = 1,
                    ArtImageId = 6
                },
                new Artwork()
                {
                    Id = 7,
                    Name = "Angel of Judgement with Sword",
                    Description = "A painting with a religious theme, depicting an angel with a longsword, in anticipation of the Day of Judgment.",
                    ArtistId = 3,
                    ArtImageId = 7
                },
                new Artwork()
                {
                    Id = 8,
                    Name = "Camille de Caen - the younger sister of Caitlin",
                    Description = "The painting shows a young woman—named Camille de Caen—who is Caitlin’s younger sister.",
                    ArtistId = 4,
                    ArtImageId = 8
                },
                new Artwork()
                {
                    Id = 9,
                    Name = "Seraphine Morne with a Castle in the Background",
                    Description = "The painting depicts Countess Seraphine Morne, with a castle in the background illuminated by the full moon.",
                    ArtistId = 4,
                    ArtImageId = 9
                },
                new Artwork()
                {
                    Id = 10,
                    Name = "All Flowers remember Her",
                    Description = "The painting depicts a muse from antiquity surrounded by roses and lilies.",
                    ArtistId = 2,
                    ArtImageId = 10
                },
                new Artwork()
                {
                    Id = 11,
                    Name = "Edelweiss and Sunlight",
                    Description = "The painting shows a woman from the Alps in the sunlight, wearing traditional attire.",
                    ArtistId = 3,
                    ArtImageId = 11
                },
                new Artwork()
                {
                    Id = 12,
                    Name = "Wealthy merchant's daughter wearing an ornate blue embroidered Turban",
                    Description = "A portrait of a wealthy merchant's daughter from the late Middle Ages with an exotic appearance and a blue headdress - probably an ornate blue embroidered turban",
                    ArtistId = 1,
                    ArtImageId = 12
                },
                new Artwork()
                {
                    Id = 13,
                    Name = "Monochrome Melancholy",
                    Description = "The painting depicts a modern woman in a black dress and a grey coat, set against a similarly grey background. The theme of this painting is, quite clearly, melancholy.",
                    ArtistId = 2,
                    ArtImageId = 13
                },
                new Artwork()
                {
                    Id = 14,
                    Name = "Solitude among Blooms",
                    Description = "A beautiful woman wearing a pink dress, with long brown hair, sits peacefully among the pink roses.",
                    ArtistId = 3,
                    ArtImageId = 14
                },
                new Artwork()
                {
                    Id = 15,
                    Name = "A Face carved from Sunlight",
                    Description = "The painting depicts a magnificent and inspirational muse from antiquity, whose face is sculpted from sunlight.",
                    ArtistId = 4,
                    ArtImageId = 15
                },
                new Artwork()
                {
                    Id = 16,
                    Name = "Portrait of Victorian Lady Prudence Whitmore",
                    Description = "This portrait shows the Victorian Lady Prudence Whitmore with a bright yellow flower in her hair.",
                    ArtistId = 2,
                    ArtImageId = 16
                },
                new Artwork()
                {
                    Id = 17,
                    Name = "Where the Meadow whispers",
                    Description = "This painting depicts a woman in a black dress lying on a dark green meadow.",
                    ArtistId = 4,
                    ArtImageId = 17
                },
                new Artwork()
                {
                    Id = 18,
                    Name = "The Silent Oracle of Delos",
                    Description = "This painting, with its light and bright colors, depicts a muse from antiquity surrounded by classical columns.",
                    ArtistId = 4,
                    ArtImageId = 18
                },
                new Artwork()
                {
                    Id = 19,
                    Name = "The High Priestess of the Sun",
                    Description = "A painting with a mystical theme, depicting the high priestess of the sun.",
                    ArtistId = 2,
                    ArtImageId = 19
                },
                new Artwork()
                {
                    Id = 20,
                    Name = "The Muse near a Temple",
                    Description = "This painting depicts a muse in a light-pink dress, with classical columns on the left-hand side; she is likely in the vicinity of a temple.",
                    ArtistId = 4,
                    ArtImageId = 20
                },
                new Artwork()
                {
                    Id = 21,
                    Name = "Portrait of Princess Élodie de Montclair",
                    Description = "A portrait of a young princess named Élodie de Montclair, wearing a blue dress and a tiara set with sapphires.",
                    ArtistId = 1,
                    ArtImageId = 21
                },
                new Artwork()
                {
                    Id = 22,
                    Name = "Portrait of Juliette Laurent",
                    Description = "This painting shows an ordinary woman who is incredibly beautiful and whose name is Juliette Laurent.",
                    ArtistId = 4,
                    ArtImageId = 22
                },
                new Artwork()
                {
                    Id = 23,
                    Name = "Vigil at Midnight",
                    Description = "A mysterious painting depicting a woman in white attire, holding a candle in her hands.", 
                    ArtistId = 2,
                    ArtImageId = 23
                },
                new Artwork()
                {
                    Id = 24,
                    Name = "The Angel of Light and Grace",
                    Description = "This painting depicts an angel with white hair and white clothing, who is both graceful and a bringer of light.",
                    ArtistId = 4,
                    ArtImageId = 24
                },
                new Artwork()
                {
                    Id = 25,
                    Name = "Unknown Victorian Lady with Mirror in the background",
                    Description = "Portrait of an unknown Victorian Lady dressed in a casual gown, with a mirror and a low cabinet in the background.",
                    ArtistId = 3,
                    ArtImageId = 25
                },
                new Artwork()
                {
                    Id = 26,
                    Name = "Where the Sky meets the Grain",
                    Description = "This painting shows a woman in a light-blue dress standing in the middle of a grain field.",
                    ArtistId = 2,
                    ArtImageId = 26
                },
                new Artwork()
                {
                    Id = 27,
                    Name = "Portrait of Isolde de Beaumont", 
                    Description = "A portrait executed by the artist Dolores Abernathy, depicting a young Victorian woman named Isolde de Beaumont.",
                    ArtistId = 1,
                    ArtImageId = 27
                },
                new Artwork()
                {
                    Id = 28,
                    Name = "The Marquise in Scarlet Brocade",
                    Description = "This painting depicts an unknown marquise dressed in an exquisite 18th-century red dress richly decorated with brocade.",
                    ArtistId = 2,
                    ArtImageId = 28
                },
                new Artwork()
                {
                    Id = 29,
                    Name = "Portrait of Genevieve de Montrose",
                    Description = "A portrait created by the artist Elena Marchetti, depicting a young Victorian woman named Genevieve de Montrose, dressed in a blue gown and wearing a flower in her hair.",
                    ArtistId = 2,
                    ArtImageId = 29
                },
                new Artwork()
                {
                    Id = 30,
                    Name = "Woman in a red dress looking over the Town",
                    Description = "The foreground of this painting shows a beautiful woman dressed in a summery red dress, sitting on a balcony, while a town can be seen in the background.",
                    ArtistId = 3,
                    ArtImageId = 30
                },
                new Artwork()
                {
                    Id = 31,
                    Name = "Blossom and Sunlight",
                    Description = "A painting that evokes cheerfulness; this artwork depicts a young blonde woman amidst a field of pink flowers.",
                    ArtistId = 3,
                    ArtImageId = 31
                },
                new Artwork()
                {
                    Id = 32,
                    Name = "Lost Hopes at the Winter Station",
                    Description = "The painting depicts a young woman dressed in green, waiting for a train at a snow-covered railway station, and this artwork evokes a sense of sadness.",
                    ArtistId = 2,
                    ArtImageId = 32
                }
            );
        }
    }

}