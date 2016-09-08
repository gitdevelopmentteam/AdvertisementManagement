using System.Data.Entity;
using AdvertisementManagement.Common.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AdvertisementManagement.Repository
{
    public class ApplicationDbContext: IdentityDbContext<User>
    {
        public ApplicationDbContext(): base("AdvertisementManagementContext", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Attribute> Attributes { get; set; } 
        public DbSet<AttributeValue> AttributeValues { get; set; } 
        public DbSet<AuctionItem> AuctionItems { get; set; } 
        public DbSet<Bid> Bids { get; set; } 
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<ProductType> ProductTypes { get; set; } 
         
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}