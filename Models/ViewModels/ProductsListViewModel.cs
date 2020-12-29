using System.Collections.Generic;
using Technics.com.Models;

namespace Technics.ViewModels
{
    public class ProductsListViewModel
    {

        public IEnumerable<Product> ProductsOnLoad { get; set; }

        public List<long> AllManufacturersChosenCategory { get; set; }

        public string CurrentCategory { get; set; }

        public long CurrentCategoryId { get; set; }

        public PageInfo PageInfo { get; set; }

        public List<long> ChosenManufacturersId { get; set; }

        public int CurrentMinPrice { get; set; }

        public int CurrentMaxPrice { get; set; }

        public int MinPriсe { get; set; }

        public int MaxPrice { get; set; }

        public string SortBy { get; set; }
    }
}
