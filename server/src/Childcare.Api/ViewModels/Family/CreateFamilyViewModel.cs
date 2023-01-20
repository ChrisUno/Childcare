using System.ComponentModel.DataAnnotations;
using Childcare.Api.ViewModels.Users;
using FluentValidation;

namespace Childcare.Api.ViewModels.Family;

public class CreateFamilyViewModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    
}

public class CreateFamilyValidator : AbstractValidator<CreateFamilyViewModel>
{
    public CreateFamilyValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("Name must have more than three, but less than fifty characters");

    }
}