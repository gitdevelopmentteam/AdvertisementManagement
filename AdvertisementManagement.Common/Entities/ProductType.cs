using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdvertisementManagement.Common.Entities
{
    public class ProductType : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<AttributeValue> AttributeValues { get; set; }
        public virtual Product Product { get; set; }
    }
}
