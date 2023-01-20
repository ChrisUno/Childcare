using FluentValidation;

namespace Childcare.Api.ViewModels.RelationshipTypes;

public class CreateRelationshipTypeViewModel
{
    public string Relationship { get; set; }
}

public class CreateRelationshipTypeValidator : AbstractValidator<CreateRelationshipTypeViewModel>
{
    public CreateRelationshipTypeValidator()
    {
        RuleFor(x => x.Relationship)
            .NotNull()
            .Length(3, 50)
            .Matches(@"^[a-zA-Z-']*$")
            .WithMessage("Relationship must have three or more, but less than fifty characters");

    }
}