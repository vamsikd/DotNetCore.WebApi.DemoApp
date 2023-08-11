using DemoApp.API.Dto;
using FluentValidation;

namespace DemoApp.API.Validations
{
    public class AddProductRequestDtoValidator : AbstractValidator<AddProductRequestDto> 
    {
        public AddProductRequestDtoValidator()
        {
            RuleFor(d => d.Name).NotNull().NotEmpty();
            RuleFor(d => d.Description).MaximumLength(200);

        }
    }
}
