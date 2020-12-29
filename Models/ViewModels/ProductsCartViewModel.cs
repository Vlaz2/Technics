using System.Collections.Generic;
using Technics.com.Models;

namespace Technics.com.ViewModels
{
    public class ProductsCartViewModel
    {
        public List<Product> Products { get; set; }

        public int ProductsCount { get; set; }

        public int Price { get; set; }
    }
}
