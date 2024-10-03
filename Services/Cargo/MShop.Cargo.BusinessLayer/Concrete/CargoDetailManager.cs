using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DataAccessLayer.Abstract;
using MShop.Cargo.EntityLayer.Concrete;

namespace MShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : GenericManager<CargoDetail>, ICargoDetailService
    {
        public CargoDetailManager(ICargoDetailDal genericDal) : base(genericDal)
        {
        }
    }
}
