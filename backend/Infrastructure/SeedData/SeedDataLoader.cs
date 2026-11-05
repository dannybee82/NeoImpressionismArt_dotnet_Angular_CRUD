using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public class SeedDataLoader
    {

        private static readonly string SeedRootImages = Path.Combine(AppContext.BaseDirectory, "SeedData", "Files", "Images");

        public static byte[] LoadImage(string fileName) => File.ReadAllBytes(Path.Combine(SeedRootImages, fileName));

    }
}
