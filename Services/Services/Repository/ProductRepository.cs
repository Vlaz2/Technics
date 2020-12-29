using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Technics.com.Enums;
using Technics.com.Interfaces;
using Technics.com.Models;

namespace Technics.Repository
{
    public class ProductRepository : IAllProducts
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public List<Product> Products()
        {
            var products = appDbContext.Products.Include(x => x.Category).
                 Include(x => x.Manufacturer).
                 Include(x => x.ProductsOrders).
                 Include(x => x.Imgs).
                 Include(x => x.Comments).
                 ThenInclude(x => x.User).
                 ToList();

            foreach (var product in products)
                product.Comments = product.Comments.OrderByDescending(x => x.DateTime).ToList();

            return products;
        }

        public List<Product> GetProductsByPrice(int currentMaxP, int currentMinP, List<Product> allProductsChosenCategory, string sortBy)
        {
            if (currentMaxP != 0)
                allProductsChosenCategory = allProductsChosenCategory.Where(x => x.Price >= currentMinP).Where(x => x.Price <= currentMaxP).ToList();

            switch (sortBy)
            {
                case SortPrice.FROM_EXP_TO_CH:
                    allProductsChosenCategory = allProductsChosenCategory.OrderByDescending(x => x.Price).ToList();
                    break;
                case SortPrice.FROM_CH_TO_EXP:
                    allProductsChosenCategory = allProductsChosenCategory.OrderBy(x => x.Price).ToList();
                    break;
                case SortPrice.POPULAR:
                    allProductsChosenCategory = GetFavProducts(allProductsChosenCategory.Select(x => x.Id).ToList());
                    break;
                default:
                    break;
            }
            return allProductsChosenCategory;
        }

        public Product GetObjectProduct(long productId)
        {
            return Products().FirstOrDefault(x => x.Id == productId);
        }

        private List<Product> GetProductsRecursionCategory(long id)
        {
            var total = new List<Product>();
            total.AddRange(Products().Where(x => x.Category.Id == id));
            var categories = appDbContext.Categories.Where(x => x.ParentCategory.Id == id);

            foreach (var category in categories)
                total.AddRange(GetProductsRecursionCategory(category.Id));

            return total;
        }

        public List<Product> GetProductsByCategoryId(long id)
        {
            if (id == 0)
                return Products();

            var products = GetProductsRecursionCategory(id);
            return products.ToList();
        }

        public async Task CreateProductAsync(Product product)
        {
            product.Imgs = product.Imgs.Where(x => x.ImgUrl != null).ToList();
            await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(long id)
        {
            var _product = GetObjectProduct(id);
            appDbContext.Products.Remove(_product);
            await appDbContext.SaveChangesAsync();
        }

        public List<Product> GetProductsByManufacturesId(List<long> ids, List<Product> productsForSorting)
        {
            var sortedProducts = new List<Product>();

            foreach (var id in ids)
                sortedProducts.AddRange(productsForSorting.Where(x => x.ManufacturerId == id).ToList());

            return sortedProducts;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var imgs = appDbContext.Photos.Where(x => x.ProductId == product.Id).ToList();
            appDbContext.Photos.RemoveRange(imgs);

            var _product = appDbContext.Products.FirstOrDefault(x => x.Id == product.Id);
            _product.ManufacturerId = product.ManufacturerId;
            _product.Name = product.Name;
            _product.ShortDescription = product.ShortDescription;
            _product.LongDescription = product.LongDescription;
            _product.CategoryId = product.CategoryId;
            _product.Price = product.Price;
            _product.AmountInStock = product.AmountInStock;
            _product.Imgs = product.Imgs.Where(x=>x.ImgUrl != null).ToList();

            await appDbContext.SaveChangesAsync();
        }

        public List<Product> GetFavProducts(List<long> ids)
        {
            List<Product> favProducts = new List<Product>();

            foreach (var id in ids)
                favProducts.Add(appDbContext.Products.FirstOrDefault(x => x.Id == id));

            favProducts = favProducts.OrderByDescending(x => x.ProductsOrders.Sum(e => e.Count)).ToList();
            return favProducts;
        }

        public async Task CreateProductsFromFileAsync(List<Product> products)
        {
            foreach (var product in products)
                if (appDbContext.Categories.Any(x => x.CategoryName == product.Category.CategoryName && x.ParentCategory != null) &&
                    appDbContext.Manufacturers.Any(x => x.Name == product.Manufacturer.Name))
                {
                    product.Manufacturer = appDbContext.Manufacturers.FirstOrDefault(x => x.Name == product.Manufacturer.Name);
                    product.Category = appDbContext.Categories.FirstOrDefault(x => x.CategoryName == product.Category.CategoryName);
                    await appDbContext.Products.AddAsync(product);
                    await appDbContext.SaveChangesAsync();
                }
        }
    }
}
