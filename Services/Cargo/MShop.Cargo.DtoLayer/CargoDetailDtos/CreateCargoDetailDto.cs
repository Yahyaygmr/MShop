using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Cargo.DtoLayer.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {
        public string SenderCustomer { get; set; } //Gönderici Müşteri
        public string RecieverCustomer { get; set; } //Alıcı Müşteri
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
