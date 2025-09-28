using AutoMapper;
using Backer.Application.Features.SolutionAssignToDifficult.Dtos;
using Backer.Core.Interfaces;
using Backer.Core.Entities;
using MediatR;

namespace Backer.Application.Features.SolutionAssignToDifficult.Queries;

public record GetAssignmentByIdQuery(int Id) : IRequest<SolutionAssignToDifficultDto>;

public class GetAssignmentByIdQueryHandler
    : IRequestHandler<GetAssignmentByIdQuery, SolutionAssignToDifficultDto>
{
    private readonly IRepository<Backer.Core.Entities.SolutionAssignToDifficult> _repository;
    private readonly IMapper _mapper;

    public GetAssignmentByIdQueryHandler(
        IRepository<Backer.Core.Entities.SolutionAssignToDifficult> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SolutionAssignToDifficultDto> Handle(
        GetAssignmentByIdQuery request,
        CancellationToken ct)
    {
        var assignment = await _repository.GetByIdWithIncludeAsync(
            request.Id,
            a => a.Difficult,
            a => a.Solution);

        return _mapper.Map<SolutionAssignToDifficultDto>(assignment);
    }
}