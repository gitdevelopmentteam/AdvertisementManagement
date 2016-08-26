using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisementManagement.Common.Entities
{
    public class Bid: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("AuctionItem")]
        public int AuctionItemId { get; set; }
        public string Comment { get; set; }
        public virtual User User { get; set; }
        public virtual AuctionItem AuctionItem { get; set; }
    }
}
