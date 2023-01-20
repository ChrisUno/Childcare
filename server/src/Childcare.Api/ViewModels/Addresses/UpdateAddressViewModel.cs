using FluentValidation;

namespace Childcare.Api.ViewModels.Addresses;

public class UpdateAddressViewModel
{
    public string Name { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    
    public string Region { get; set; }
    
    public string Country { get; set; }
    
    public string Zipcode { get; set; }
}

public class UpdateAddressValidator : AbstractValidator<UpdateAddressViewModel>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.AddressLine1)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("First line of your address must be more than 3 but less than 50 characters long");
        
        RuleFor(x => x.AddressLine2)
            .NotNull()
            .Length(3, 50)
            .WithMessage("Second line of your address must be more than 3 but less than 50 characters long");
        
        RuleFor(x => x.Region)
            .NotNull()
            .Length(2, 20)
            .WithMessage("The County must be more than 2 but less than 20 characters long");
        
        RuleFor(x => x.Country)
            .NotNull()
            .Length(2, 30)
            .WithMessage("The City must be more than 2 but less than 30 characters long");
        
        RuleFor(x => x.Zipcode)
            .NotNull()
            .Length(4, 10)
            .WithMessage("Your Postcode must be most than 4 but less than 10 characters long");
    }
}