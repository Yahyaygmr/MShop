using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DtoLayer.CargoDetailDtos;

namespace MShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            _cargoDetailService.Insert(new() {
                Barcode = dto.Barcode,
                CargoCompanyId = dto.CargoCompanyId,
               RecieverCustomer = dto.RecieverCustomer,
               SenderCustomer = dto.SenderCustomer,
            });
            return Ok("Kargo Detayı Başarıyla Eklendi !");
        }
        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.Delete(id);
            return Ok("Kargo Detayı Başarıyla Silindi !");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            var values = _cargoDetailService.GetById(dto.CargoDetailId);
            values.CargoCompanyId = dto.CargoCompanyId;
            values.RecieverCustomer = dto.RecieverCustomer;
            values.SenderCustomer = dto.SenderCustomer;
            values.Barcode = dto.Barcode;
     
            _cargoDetailService.Update(values);
            return Ok("Kargo Detayı Başarıyla Güncellendi !");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.GetById(id);
            return Ok(value);
        }
    }
}
