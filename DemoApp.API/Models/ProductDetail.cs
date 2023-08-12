using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.API.Models
{
    public class ProductDetail : BaseEntity
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }
        public int Discount { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public bool InStock { get { return AvailableQuantity > 0; } }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
