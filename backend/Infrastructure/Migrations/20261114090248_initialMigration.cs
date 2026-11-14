using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NeoImpressionismArt");

            migrationBuilder.CreateTable(
                name: "ArtImages",
                schema: "NeoImpressionismArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                schema: "NeoImpressionismArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    YearOfBirth = table.Column<int>(type: "integer", nullable: true),
                    YearOfDeath = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                schema: "NeoImpressionismArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: true),
                    ArtImageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artworks_ArtImages_ArtImageId",
                        column: x => x.ArtImageId,
                        principalSchema: "NeoImpressionismArt",
                        principalTable: "ArtImages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artworks_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "NeoImpressionismArt",
                        principalTable: "Artists",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "NeoImpressionismArt",
                table: "Artists",
                columns: new[] { "Id", "Description", "Name", "YearOfBirth", "YearOfDeath" },
                values: new object[,]
                {
                    { 1, "This artist's mysterious background is reflected in her enigmatic paintings, where colorful strokes meet photographic detail. Each piece tells a rich story, balancing playful creativity with profound depth.", "Dolores Abernathy", 1987, null },
                    { 2, "A luminous colorist who builds her canvases from small, deliberate dabs of pure pigment. Her scenes of Mediterranean colors and use of sunlight shimmer with vibrant contrasts.", "Elena Marchetti", 1986, null },
                    { 3, "A methodical painter who applies Abernathy's a special technique to his paintings. His artworks balance structured geometry with soft, atmospheric light.", "Théodore Blanchard", 1987, null },
                    { 4, "A poetic draftsman of color who blends the Neo Impressionist style with delicate compositions. Her artworks of women in blossoming orchids and misty coastlines feel serene and airy.", "Yuki Nakamura", 1986, null }
                });

            migrationBuilder.InsertData(
                schema: "NeoImpressionismArt",
                table: "Artworks",
                columns: new[] { "Id", "ArtImageId", "ArtistId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, 2, "The painting shows a woman in a beautiful green and red dress, standing upright on a swing in the forest.", "The Swing Beneath the Canopy" },
                    { 2, null, 1, "The painting shows a beautiful woman with dark hair stands in the vineyard, lost in her own thoughts.", "Harvest Reverie in the Vineyard" },
                    { 3, null, 3, "The painting depicts a guardian angel with an aura, holding a candle in her hand.", "Guardian angel with a Candle" },
                    { 4, null, 4, "The painting depicts an alluring woman standing in front of a mirror, accompanied by magical light effects.", "The Magic Mirror" },
                    { 5, null, 2, "The painting depicts a woman lying in a field of flowers on a sunny day in May.", "A Quiet Hour in May" },
                    { 6, null, 1, "A portrait made by Dolores Abernathy showing the noblewoman Éléonore de Valcour.", "Portrait of Éléonore de Valcour" },
                    { 7, null, 3, "A painting with a religious theme, depicting an angel with a longsword, in anticipation of the Day of Judgment.", "Angel of Judgement with Sword" },
                    { 8, null, 4, "The painting shows a young woman—named Camille de Caen—who is Caitlin’s younger sister.", "Camille de Caen - the younger sister of Caitlin" },
                    { 9, null, 4, "The painting depicts Countess Seraphine Morne, with a castle in the background illuminated by the full moon.", "Seraphine Morne with a Castle in the Background" },
                    { 10, null, 2, "The painting depicts a muse from antiquity surrounded by roses and lilies.", "All Flowers remember Her" },
                    { 11, null, 3, "The painting shows a woman from the Alps in the sunlight, wearing traditional attire.", "Edelweiss and Sunlight" },
                    { 12, null, 1, "A portrait of a wealthy merchant's daughter from the late Middle Ages with an exotic appearance and a blue headdress - probably an ornate blue embroidered turban", "Wealthy merchant's daughter wearing an ornate blue embroidered Turban" },
                    { 13, null, 2, "The painting depicts a modern woman in a black dress and a grey coat, set against a similarly grey background. The theme of this painting is, quite clearly, melancholy.", "Monochrome Melancholy" },
                    { 14, null, 3, "A beautiful woman wearing a pink dress, with long brown hair, sits peacefully among the pink roses.", "Solitude among Blooms" },
                    { 15, null, 4, "The painting depicts a magnificent and inspirational muse from antiquity, whose face is sculpted from sunlight.", "A Face carved from Sunlight" },
                    { 16, null, 2, "This portrait shows the Victorian Lady Prudence Whitmore with a bright yellow flower in her hair.", "Portrait of Victorian Lady Prudence Whitmore" },
                    { 17, null, 4, "This painting depicts a woman in a black dress lying on a dark green meadow.", "Where the Meadow whispers" },
                    { 18, null, 4, "This painting, with its light and bright colors, depicts a muse from antiquity surrounded by classical columns.", "The Silent Oracle of Delos" },
                    { 19, null, 2, "A painting with a mystical theme, depicting the high priestess of the sun.", "The High Priestess of the Sun" },
                    { 20, null, 4, "This painting depicts a muse in a light-pink dress, with classical columns on the left-hand side; she is likely in the vicinity of a temple.", "The Muse near a Temple" },
                    { 21, null, 1, "A portrait of a young princess named Élodie de Montclair, wearing a blue dress and a tiara set with sapphires.", "Portrait of Princess Élodie de Montclair" },
                    { 22, null, 4, "This painting shows an ordinary woman who is incredibly beautiful and whose name is Juliette Laurent.", "Portrait of Juliette Laurent" },
                    { 23, null, 2, "A mysterious painting depicting a woman in white attire, holding a candle in her hands.", "Vigil at Midnight" },
                    { 24, null, 4, "This painting depicts an angel with white hair and white clothing, who is both graceful and a bringer of light.", "The Angel of Light and Grace" },
                    { 25, null, 3, "Portrait of an unknown Victorian Lady dressed in a casual gown, with a mirror and a low cabinet in the background.", "Unknown Victorian Lady with Mirror in the background" },
                    { 26, null, 2, "This painting shows a woman in a light-blue dress standing in the middle of a grain field.", "Where the Sky meets the Grain" },
                    { 27, null, 1, "A portrait executed by the artist Dolores Abernathy, depicting a young Victorian woman named Isolde de Beaumont.", "Portrait of Isolde de Beaumont" },
                    { 28, null, 2, "This painting depicts an unknown marquise dressed in an exquisite 18th-century red dress richly decorated with brocade.", "The Marquise in Scarlet Brocade" },
                    { 29, null, 2, "A portrait created by the artist Elena Marchetti, depicting a young Victorian woman named Genevieve de Montrose, dressed in a blue gown and wearing a flower in her hair.", "Portrait of Genevieve de Montrose" },
                    { 30, null, 3, "The foreground of this painting shows a beautiful woman dressed in a summery red dress, sitting on a balcony, while a town can be seen in the background.", "Woman in a red dress looking over the Town" },
                    { 31, null, 3, "A painting that evokes cheerfulness; this artwork depicts a young blonde woman amidst a field of pink flowers.", "Blossom and Sunlight" },
                    { 32, null, 2, "The painting depicts a young woman dressed in green, waiting for a train at a snow-covered railway station, and this artwork evokes a sense of sadness.", "Lost Hopes at the Winter Station" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtImageId",
                schema: "NeoImpressionismArt",
                table: "Artworks",
                column: "ArtImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistId",
                schema: "NeoImpressionismArt",
                table: "Artworks",
                column: "ArtistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artworks",
                schema: "NeoImpressionismArt");

            migrationBuilder.DropTable(
                name: "ArtImages",
                schema: "NeoImpressionismArt");

            migrationBuilder.DropTable(
                name: "Artists",
                schema: "NeoImpressionismArt");
        }
    }
}
