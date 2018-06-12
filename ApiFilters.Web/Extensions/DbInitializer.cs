using ApiFilters.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFilters.Web.Extensions
{
    public static class DbInitializer
    {
        public static void Initialize(this AppDbContext db)
        {
            db.Database.EnsureCreated();

            if (!(db.Products.Any()))
            {
                var products = new List<Product>()
                {
                    new Product { Name = "Red Copper Pans" },
                    new Product { Name = "Sham Wow!" },
                    new Product { Name = "Egg Sitter" },
                    new Product { Name = "Body Buddy" },
                    new Product { Name = "Shake Weight" },
                    new Product { Name = "Sock Slider" },
                    new Product { Name = "Flex Seal" },
                    new Product { Name = "Air Dragon Deluxe" },
                    new Product { Name = "Atomic Lighter" },
                    new Product { Name = "5 Minute Mani" },
                    new Product { Name = "Fix Tape 8" },
                    new Product { Name = "Bavarian Edge" },
                    new Product { Name = "Slobproof Paint Pens" }
                };

                db.Products.AddRange(products);
                db.SaveChanges();
            }
        }
    }
}
