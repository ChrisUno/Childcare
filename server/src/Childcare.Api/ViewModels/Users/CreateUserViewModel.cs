using FluentValidation;
using System.Security;


namespace Childcare.Api.ViewModels.Users;

public class CreateUserViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    //public FamilyViewModel Name { get; set; }

    //public AddressViewModel Address { get; set; }
    
}

public class CreateUserValidator : AbstractValidator<CreateUserViewModel>
{
    public CreateUserValidator()
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
