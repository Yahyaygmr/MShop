using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DtoLayer.CargoCompanyDtos;
using System.Diagnostics.Contracts;

namespace MShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            _cargoCompanyService.Insert(new() { CargoCompanyName = dto.CargoCompanyName});
            return Ok("Kargo Şirketi Başarıyla Eklendi !");
        }
        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
            _cargoCompanyService.Delete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi !");
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var values = _cargoCompanyService.GetById(dto.CargoCompanyId);
            values.CargoCompanyName = dto.CargoCompanyName;
            _cargoCompanyService.Update(values);
            return Ok("Kargo Şirketi Başarıyla Güncellendi !");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.GetById(id);
            return Ok(value);
        }
    }
}
