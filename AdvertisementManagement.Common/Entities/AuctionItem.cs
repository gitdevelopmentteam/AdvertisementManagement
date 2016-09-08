using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisementManagement.Common.Entities
{
    public class AuctionItem: IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime PlannedCloseDate { get; set; }
        [Required]
        public decimal ActualSellingPrice { get; set; }
        [Required]
        public decimal ReservePrice { get; set; }
        public int SuccessfulUserId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Comment { get; set; }
        [Required]
        public Status Status { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
