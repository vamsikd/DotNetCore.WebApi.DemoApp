namespace DemoApp.API.Dto
{
    public class UpdateCategoryRequestDto
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
