using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DataAccessLayer.Abstract;
using MShop.Cargo.EntityLayer.Concrete;

namespace MShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : GenericManager<CargoOperation>, ICargoOperationService
    {
        public CargoOperationManager(ICargoOperationDal genericDal) : base(genericDal)
        {
        }
    }
}
