using DemoApp.API.Dto;
using FluentValidation;

namespace DemoApp.API.Validations
{
    public class UpdateProductRequestDtoValidator : AbstractValidator<UpdateProductRequestDto> 
    {
        public UpdateProductRequestDtoValidator()
        {
            RuleFor(d => d.Id).NotNull().NotEmpty();
            RuleFor(d => d.Name).NotNull().NotEmpty();
            RuleFor(d => d.CategoryId).NotNull().NotEmpty();
            RuleFor(d => d.AvailableQuantity).NotNull().NotEmpty();
            RuleFor(d => d.Discount).NotNull().NotEmpty();
            RuleFor(d => d.Price).NotNull().NotEmpty();

            //Data Validations
            RuleFor(d => d.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than equal to 0 ")
                .LessThanOrEqualTo(99).WithMessage("Discount must be Leass than equal to 99 ");
            RuleFor(d => d.Description).MaximumLength(200);

        }
    }
}
