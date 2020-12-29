using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Repository
{
    public class ShopCartRepository
    {
        private readonly AppDbContext appDbContext;

        public ShopCartRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Product> GetShopCartItems(List<long> ids)
        {
            List<Product> products = new List<Product>();

            foreach (var id in ids)
                products.Add(appDbContext.Products.FirstOrDefault(x => x.Id == id));

            return products;
        }
    }
}
