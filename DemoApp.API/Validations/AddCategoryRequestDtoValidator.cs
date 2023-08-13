using DemoApp.API.Dto;
using DemoApp.API.Models;
using FluentValidation;
using NPOI.SS.Formula.Functions;

namespace DemoApp.API.Validations
{
    public class AddCategorytRequestDtoValidator : AbstractValidator<AddCategoryRequestDto> 
    {
        public AddCategorytRequestDtoValidator()
        {
            RuleFor(d => d.Code).NotNull().NotEmpty()
                .Length(5).WithMessage("Category Code must be of length 5");
            RuleFor(d => d.Name).NotNull().NotEmpty();
            RuleFor(d => d.Description).MaximumLength(200);
        }
    }
}
