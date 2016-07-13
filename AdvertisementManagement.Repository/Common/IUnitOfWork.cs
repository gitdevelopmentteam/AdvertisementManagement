using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementManagement.Repository.Common
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save all pending changes
        /// </summary>
        /// <returns>Number of objects in an added, deleted or modefied state</returns>
        int Commit();

        Task<int> CommitAsync();
    }
}
