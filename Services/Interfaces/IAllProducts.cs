using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Models;

namespace Technics.com.Interfaces
{
    public interface IAllProducts
    {
         List<Product> Products();

        Product GetObjectProduct(long productId);

        Task CreateProductAsync(Product product);

        Task DeleteProductAsync(long id);

        List<Product> GetProductsByCategoryId(long id);

        Task UpdateProductAsync(Product product);

        List<Product> GetFavProducts(List<long> ids);

        List<Product> GetProductsByPrice(int currentMaxP, int currentMinP, List<Product> allProductsChosenCategory, string sortBy);

        Task CreateProductsFromFileAsync(List<Product> products);

        List<Product> GetProductsByManufacturesId(List<long> ids,List<Product> productsForSorting);
    }
}
