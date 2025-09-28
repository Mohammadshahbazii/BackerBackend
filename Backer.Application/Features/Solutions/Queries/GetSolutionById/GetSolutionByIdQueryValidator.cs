using FluentValidation;

namespace Backer.Application.Features.Solutions.Queries.GetSolutionById;

public class GetSolutionByIdQueryValidator : AbstractValidator<GetSolutionByIdQuery>
{
    public GetSolutionByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Solution ID must be greater than 0");
    }
}