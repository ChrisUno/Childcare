using FluentValidation;

namespace Childcare.Api.ViewModels.Users;

public class UpdateUserViewModel
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public RelationshipTypeViewModel Name { get; set; }
}

public class UpdateUserValidator : AbstractValidator<UpdateUserViewModel>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("First name must be supplied and between 3 and 50 characters");
        
        RuleFor(x => x.LastName)
            .NotNull()
            .Length(3, 50)
            .WithMessage("Last name must be supplied and between 3 and 50 characters");
    }
}
