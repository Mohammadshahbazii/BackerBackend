using Backer.Application.Features.Solutions.Dtos;
using MediatR;

namespace Backer.Application.Features.Solutions.Queries.GetSolutionById;

public record GetSolutionByIdQuery(int Id) : IRequest<SolutionDto>;