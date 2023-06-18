using FluentValidation;
using FluentValidation.AspNetCore;
using Gym.Models.Request;
using System.Linq.Expressions;

namespace Gym.Controllers.Validators
{
    public class AddManufacturerRequestValidator :
        AbstractValidator<AddManufacturerRequest>
    {
        public AddManufacturerRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Zapishete ime")
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(18);

            RuleFor(x => x.Info)
                .NotEmpty();
        }

    }
}
