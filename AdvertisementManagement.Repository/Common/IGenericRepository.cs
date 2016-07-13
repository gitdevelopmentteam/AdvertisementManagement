using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AdvertisementManagement.Common.Entities;

namespace AdvertisementManagement.Repository.Common
{
    public interface IGenericRepository<T> where T: class, IEntity
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        void Update(T trackedEntity, T model);
        T Delete(T entity);
        void Save();

        //async
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        Task SaveAsync();
    }
}
