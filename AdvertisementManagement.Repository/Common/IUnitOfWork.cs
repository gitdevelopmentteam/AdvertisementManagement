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
