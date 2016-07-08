using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisementManagement.Common.Entities
{
    public class Product: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("ProductType")]
        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
