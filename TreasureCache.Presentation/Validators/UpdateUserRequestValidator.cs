using FluentValidation;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.Validators;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.PersonalDiscount)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .LessThan(80);

        RuleFor(x => x.SelectedRoles)
            .NotEmpty();

        RuleFor(x => x.SignedUpForNewsletter)
            .NotNull();
    }
}