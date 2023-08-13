using DemoApp.API.Dto;
using FluentValidation;

namespace DemoApp.API.Validations
{
    public class UpdateCategoryRequestDtoValidator : AbstractValidator<UpdateCategoryRequestDto> 
    {
        public UpdateCategoryRequestDtoValidator()
        {
            RuleFor(d => d.Id).NotNull().NotEmpty();
            RuleFor(d => d.Code).NotNull().NotEmpty()
                .Length(5).WithMessage("Category Code must be of length 5");
            RuleFor(d => d.Name).NotNull().NotEmpty();
            RuleFor(d => d.Description).MaximumLength(200);
        }
    }
}
