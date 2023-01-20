using System.ComponentModel.DataAnnotations;
using Childcare.Api.ViewModels.Addresses;
using FluentValidation;

namespace Childcare.Api.ViewModels.Events;

public class CreateEventViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public DateTime TimeSlot { get; set; }
    
    public CreateAddressViewModel Address { get; set; }
}

public class CreateEventValidator : AbstractValidator<CreateEventViewModel>
{
    public CreateEventValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("Name must have more than three, but less than fifty characters");
        
        RuleFor(x => x.Description)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("Description must have more than three, but less than fifty characters");
        
        RuleFor(x => x.TimeSlot)
            .NotNull()
            .WithMessage("Your time selection doesnt exist");
    }
}