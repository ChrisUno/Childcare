using FluentValidation;

namespace Childcare.Api.ViewModels.Events;

public class UpdateEventViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Timeslot { get; set; }
    public AddressViewModel Id { get; set; }
}

public class UpdateEventValidator : AbstractValidator<UpdateEventViewModel>
{
    public UpdateEventValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("Name must be more than 3 but less than 50 characters long");
        
        RuleFor(x => x.Description)
            .NotNull()
            .Length(3, 50)
            .WithMessage("Description must be more than 3 but less than 50 characters long");
        
    }
}