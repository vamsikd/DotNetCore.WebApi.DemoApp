using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.API.Models
{
    public class ArchivedProduct : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
