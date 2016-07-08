using System.ComponentModel.DataAnnotations;

namespace AdvertisementManagement.Common.Entities
{
    public class Attribute: IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
