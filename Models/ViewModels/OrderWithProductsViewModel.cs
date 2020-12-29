using System.Collections.Generic;
using Technics.com.Models;

namespace Technics.com.ViewModels
{
    public class OrderWithProductsViewModel
    {
       public  List<Product> Products { get; set; }

       public  Order Order { get; set; }
    }
}
