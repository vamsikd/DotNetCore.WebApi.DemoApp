namespace DemoApp.API.Dto
{
    public class UpdateProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public bool IsActive { get; set; }
       public int Discount { get; set; }

    }
}
