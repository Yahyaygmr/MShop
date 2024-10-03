using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Cargo.BusinessLayer.Abstract;

namespace MShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
    }
}
