using FluentValidation;
using TreasureCache.Presentation.Requests;

namespace TreasureCache.Presentation.Validators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(1000);
        RuleFor(x => x.Price)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
        RuleFor(x => x.Discount)
            .Cascade(CascadeMode.Stop)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(80);
        RuleFor(x => x.Count)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .GreaterThan(0);
        RuleFor(x => x.IsActive)
            .Cascade(CascadeMode.Stop)
            .NotNull();
        RuleFor(x => x.CategoryId)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0);
        RuleFor(x => x.LargeImage)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .Must(BeAValidImage);
        RuleFor(x => x.SmallImage)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .Must(BeAValidImage);
        RuleFor(x => x.UserManual)
            .Cascade(CascadeMode.Stop)
            .Must(BeAValidManual)
            .When(x => x.UserManual is not null)
            .WithMessage("User manual must be a pdf file");
    }
    private bool BeAValidImage(IFormFile file)
    {
        string extension = Path
            .GetExtension(file.FileName);
        string[] allowedExtensions = { ".jpg", ".png" };

        return allowedExtensions
            .Contains(extension);
    }
    
    private bool BeAValidManual(IFormFile file)
    {
        string extension = Path
            .GetExtension(file.FileName);
        string[] allowedExtensions = { ".pdf" };

        return allowedExtensions
            .Contains(extension);
    }
}