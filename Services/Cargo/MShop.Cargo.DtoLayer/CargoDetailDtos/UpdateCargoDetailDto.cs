namespace MShop.Cargo.DtoLayer.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; } //Gönderici Müşteri
        public string RecieverCustomer { get; set; } //Alıcı Müşteri
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
