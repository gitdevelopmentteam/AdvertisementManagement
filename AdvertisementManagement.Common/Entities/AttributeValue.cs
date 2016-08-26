using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisementManagement.Common.Entities
{
    /// <summary>
    /// Attribute Value
    /// </summary>
    public class AttributeValue: IEntity
    {
        public int Id { get; set; }

        [ForeignKey("Attribute")]
        public int AttributeId { get; set; }

        public string Value { get; set; }

        public AttributeType AttributeType { get; set; }

        public string Description { get; set; }

        public virtual Attribute Attribute { get; set; }
        public virtual IList<ProductType> ProductTypes { get; set; }
        public virtual IList<Product> Products { get; set; } 
    }
}
