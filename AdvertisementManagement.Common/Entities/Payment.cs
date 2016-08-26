using System.ComponentModel.DataAnnotations;

namespace AdvertisementManagement.Common.Entities
{
    public class Payment: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public PaymentMethodStatus PaymentMethodStatus { get; set; }
    }
}
