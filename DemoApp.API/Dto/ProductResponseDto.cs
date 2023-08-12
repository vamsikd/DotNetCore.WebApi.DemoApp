namespace DemoApp.API.Dto
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set;}
    }
}
