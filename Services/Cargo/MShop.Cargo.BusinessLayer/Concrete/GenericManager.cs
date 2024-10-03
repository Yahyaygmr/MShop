using MShop.Cargo.BusinessLayer.Abstract;
using MShop.Cargo.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MShop.Cargo.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Delete(int id)
        {
            _genericDal.Delete(id);
        }

        public List<T> GetAll()
        {
            return _genericDal.GetAll();
        }

        public T GetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public void Insert(T entity)
        {
            _genericDal.Insert(entity);
        }

        public void Update(T entity)
        {
            _genericDal.Update(entity);
        }
    }
}
