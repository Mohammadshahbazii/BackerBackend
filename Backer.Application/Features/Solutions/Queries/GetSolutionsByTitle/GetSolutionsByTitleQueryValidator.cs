using FluentValidation;

namespace Backer.Application.Features.Solutions.Queries.GetSolutionsByTitle;

public class GetSolutionsByTitleQueryValidator : AbstractValidator<GetSolutionsByTitleQuery>
{
    public GetSolutionsByTitleQueryValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100)
            .WithMessage("Title search term must be less than 100 characters");
    }
}