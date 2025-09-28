using Backer.Application.Features.Solutions.Dtos;
using MediatR;

namespace Backer.Application.Features.Solutions.Queries.GetSolutionsByTitle;

public record GetSolutionsByTitleQuery(string Title) : IRequest<IEnumerable<SolutionDto>>;