using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Technics.com.Models;

namespace Technics.com.Services
{
    public class FileService
    {
        public List<Product> ReadFile(IFormFile uploadedFile)
        {
            List<Product> products = new List<Product>();

            using (StreamReader sr = new StreamReader(uploadedFile.OpenReadStream()))
            {
                var fileText = sr.ReadToEnd();
                var _products = fileText.Split('*');

                foreach (var product in _products)
                {
                    var optionProduct = product.Split('|');

                    var _product = new Product { Name = optionProduct[0],
                        AmountInStock = int.Parse(optionProduct[1]),
                        ShortDescription = optionProduct[2],
                        LongDescription = optionProduct[3], 
                        Price = int.Parse(optionProduct[4]),
                        Category =  new Category { CategoryName = optionProduct[5] },
                        Manufacturer =  new Manufacturer { Name = optionProduct[6]}
                    };
                    _product.Imgs = new List<Photo>();

                    for (int i = 7; i < optionProduct.Count(); i++)
                        _product.Imgs.Add(new Photo { ImgUrl = optionProduct[i] });
                    
                    products.Add(_product);
                }
            }

            return products;
        }
    }
}
