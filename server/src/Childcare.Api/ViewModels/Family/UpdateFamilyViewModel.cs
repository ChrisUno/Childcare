using FluentValidation;

namespace Childcare.Api.ViewModels.Family;

public class UpdateFamilyViewModel
{
    public string Name { get; set; }

}

public class UpdateFamilyValidator : AbstractValidator<UpdateFamilyViewModel>
{
    public UpdateFamilyValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("Name must be more than 3 but less than 50 characters long");

        
    }
}