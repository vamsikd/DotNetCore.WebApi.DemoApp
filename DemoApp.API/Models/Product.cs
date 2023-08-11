﻿namespace DemoApp.API.Models
{
    public class Product : BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
    }
}
