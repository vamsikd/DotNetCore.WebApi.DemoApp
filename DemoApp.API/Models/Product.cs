﻿namespace DemoApp.API.Models
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public ProductDetail ProductDetail { get; set;}
    }
}
