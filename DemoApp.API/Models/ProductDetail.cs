using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.API.Models
{
    public class ProductDetail : BaseEntity
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
