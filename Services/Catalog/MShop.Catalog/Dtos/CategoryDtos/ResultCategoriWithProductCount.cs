namespace MShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoriWithProductCount
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCount { get; set; }
    }
}
