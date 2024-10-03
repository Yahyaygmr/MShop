using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DataAccessLayer.Abstract;
using MShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : GenericManager<CargoCompany>, ICargoCompanyService
    {
        public CargoCompanyManager(ICargoCompanyDal genericDal) : base(genericDal)
        {
        }
    }
}
