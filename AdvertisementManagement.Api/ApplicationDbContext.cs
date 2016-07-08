using AdvertisementManagement.Api.Infrastucture;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdvertisementManagement.Api
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): base("AdvertisementManagementContext", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}