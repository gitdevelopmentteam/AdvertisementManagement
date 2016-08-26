using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementManagement.Common.Entities;

namespace AdvertisementManagement.Service
{
    public interface IEntityService<T> where T: class, IEntity
    {
        IQueryable<T> GetAll();
        T Add(T entity);
        void Delete(T entity);
        void Update(T trackedEntity, T model);
        Task<IList<T>> GetAllAsync();
    }
}
