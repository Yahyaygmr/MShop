using MongoDB.Bson.Serialization.Attributes;
using MShop.Catalog.Entities;

namespace MShop.Catalog.Dtos.ProductDetailDtos
{
    public class ResultProductDetailDto
    {
        public string ProductDetailId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductInformation { get; set; }
        public string ProductId { get; set; }
    }
}
