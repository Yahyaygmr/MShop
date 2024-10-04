using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DtoLayer.CargoOperationDtos;

namespace MShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            _cargoOperationService.Insert(new()
            {
                Barcode = dto.Barcode,
                Description = dto.Description,
                OperationDate = dto.OperationDate
            });
            return Ok("Kargo Operasyonu Başarıyla Eklendi !");
        }
        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.Delete(id);
            return Ok("Kargo Operasyonu Başarıyla Silindi !");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var values = _cargoOperationService.GetById(dto.CargoOperationId);

            values.Barcode = dto.Barcode;
            values.Description = dto.Description;
            values.OperationDate = dto.OperationDate;

            _cargoOperationService.Update(values);
            return Ok("Kargo Operasyonu Başarıyla Güncellendi !");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.GetById(id);
            return Ok(value);
        }
    }
}
