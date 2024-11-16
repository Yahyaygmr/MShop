using MShop.DtoLayer.CatalogDtos.ProductImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ResultProductWithCategoryDto : ResultProductDto
    {
        public string CategoryName { get; set; }
    }
}
