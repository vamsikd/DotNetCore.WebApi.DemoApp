using DemoApp.API.Data;
using DemoApp.API.Dto;
using DemoApp.API.Exceptions;
using DemoApp.API.Models;
using DemoApp.API.Services.Interfaces;

namespace DemoApp.API.Services
{
    public class CategoryService : ICategoryService
    {
        private DemoAppDbContext _dbContext;
        public CategoryService(DemoAppDbContext context)
        {
            _dbContext = context;
        }

        public int Add(AddCategoryRequestDto categoryDto)
        {
            // map Dto to Model
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Code = categoryDto.Code,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Id;
        }

        public bool Update(UpdateCategoryRequestDto categoryDto)
        {
            var category = this.GetModel(categoryDto.Id);

            category.Name = categoryDto.Name;
            category.Description = categoryDto.Description;
            category.Code = categoryDto.Code;
            category.UpdatedOn = DateTime.Now;

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int categoryId)
        {
            var category = this.GetModel(categoryId);

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return true;
        }

        public CategoryResponseDto Get(int categoryId)
        {
            var category = this.GetModel(categoryId);

            var categoryResponseDto = new CategoryResponseDto();
            categoryResponseDto.Id = categoryId;
            categoryResponseDto.Name = category.Name;
            categoryResponseDto.Description = category.Description;
            categoryResponseDto.Code = category.Code;
            categoryResponseDto.CreatedOn = category.CreatedOn;
            categoryResponseDto.UpdatedOn = category.UpdatedOn;

            return categoryResponseDto;
        }

        public IEnumerable<CategoryResponseDto> GetAll()
        {
            var categories = _dbContext.Categories
                .ToList();

            var categoryResponseDtoList = categories
                .Select(c => new CategoryResponseDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code = c.Code,
                        Description = c.Description,                      
                        CreatedOn = c.CreatedOn,
                        UpdatedOn = c.UpdatedOn

                    })
                .ToList();
            return categoryResponseDtoList;
        }

        private Category GetModel(int categoryId)
        {
            var category = _dbContext.Categories
               .Find(categoryId);

            if (category == null)
                throw new NotFoundException($"Category not found for Id {categoryId}");

            return category;
        }
    }
}
