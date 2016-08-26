using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementManagement.Common.Entities;
using AdvertisementManagement.Repository.Common;

namespace AdvertisementManagement.Service
{
    public class EntityService<T>: IEntityService<T> where T: class, IEntity
    {
        private IGenericRepository<T> _repository;
        private IUnitOfWork _unitOfWork;

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T Add(T entity)
        {
            var result = _repository.Add(entity);
            _unitOfWork.Commit();
            return result;
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public void Update(T trackedEntity, T model)
        {
            _repository.Update(trackedEntity, model);
            _unitOfWork.Commit();
        }

        public Task<IList<T>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
    }
}
