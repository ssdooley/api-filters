using ApiFilters.Data;
using ApiFilters.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFilters.Web.Controllers
{
    [Route("api/[controller]")]
    public class AppController : Controller
    {
        private AppDbContext db;

        public AppController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]/{search}")]
        public async Task<List<Product>> FilterProducts([FromRoute]string search)
        {
            return await db.FilterProducts(search);
        }
    }
}
