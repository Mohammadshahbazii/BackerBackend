using FluentValidation;

namespace Backer.Application.Features.Solutions.Queries.GetAllSolutions;

public class GetAllSolutionsQueryValidator : AbstractValidator<GetAllSolutionsQuery>
{
    // No validation needed for empty query
    public GetAllSolutionsQueryValidator()
    {
    }
}