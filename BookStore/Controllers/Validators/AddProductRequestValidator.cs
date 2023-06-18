using FluentValidation;
using Gym.Models.Request;

namespace Gym.Controllers.Validators
{
    public class AddProductRequestValidator :
        AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Zapishete ime")
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20);

            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}
