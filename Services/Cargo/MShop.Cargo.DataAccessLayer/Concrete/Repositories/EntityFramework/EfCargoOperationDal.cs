using MShop.Cargo.DataAccessLayer.Abstract;
using MShop.Cargo.EntityLayer.Concrete;

namespace MShop.Cargo.DataAccessLayer.Concrete.Repositories.EntityFramework
{
    public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
    {
        public EfCargoOperationDal(CargoContext context) : base(context)
        {
        }
    }
}
