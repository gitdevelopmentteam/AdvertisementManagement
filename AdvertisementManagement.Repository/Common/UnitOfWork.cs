using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Repository.Common
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<int> CommitAsync()
        {
            try
            {
                return _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if(!disposing) return;
            _dbContext?.Dispose();
            _dbContext = null;
        }
    }
}
