using ApiFilters.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFilters.Web.Extensions
{
    public static class AppExtensions
    {
        public static async Task<List<Product>> FilterProducts(this AppDbContext db, string search)
        {
            var model = await db.Products
                .Where(x => x.Name.ToLower().Contains(search.ToLower()))
                .ToListAsync();

            return model;
        }
    }
}
