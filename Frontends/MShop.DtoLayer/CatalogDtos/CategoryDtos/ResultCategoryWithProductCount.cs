using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.DtoLayer.CatalogDtos.CategoryDtos
{
    public class ResultCategoryWithProductCount
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCount { get; set; }
    }
}
