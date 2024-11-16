using MShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MShop.DtoLayer.CatalogDtos.ProductDtos
{
    public class ResultProductWithImagesDto
    {

        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ResultProductImageDto> ProductImages { get; set; }
    }
}
