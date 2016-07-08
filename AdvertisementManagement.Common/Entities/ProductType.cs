﻿using System.ComponentModel.DataAnnotations;

namespace AdvertisementManagement.Common.Entities
{
    public class ProductType : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}