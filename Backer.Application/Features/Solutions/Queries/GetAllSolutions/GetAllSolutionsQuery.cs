using Backer.Application.Features.Solutions.Dtos;
using MediatR;

namespace Backer.Application.Features.Solutions.Queries.GetAllSolutions;

public record GetAllSolutionsQuery() : IRequest<IEnumerable<SolutionDto>>;