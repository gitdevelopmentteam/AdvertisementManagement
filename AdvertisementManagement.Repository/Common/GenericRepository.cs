using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdvertisementManagement.Common.Entities;

namespace AdvertisementManagement.Repository.Common
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class, IEntity
    {
        private IDbSet<T> _dbSet;
        private DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public void Update(T trackedEntity, T model)
        {
            _dbContext.Entry(trackedEntity).CurrentValues.SetValues(model);
            _dbContext.Entry(trackedEntity).State = EntityState.Modified;
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
