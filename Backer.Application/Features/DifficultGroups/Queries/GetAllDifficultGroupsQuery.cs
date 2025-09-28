// Application/Features/DifficultGroups/Queries/GetAllDifficultGroupsQuery.cs
using AutoMapper;
using Backer.Application.Features.DifficultGroups.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.DifficultGroups.Queries;

public record GetAllDifficultGroupsQuery() : IRequest<List<DifficultGroupDto>>;

public class GetAllDifficultGroupsQueryHandler : IRequestHandler<GetAllDifficultGroupsQuery, List<DifficultGroupDto>>
{
    private readonly IRepository<DifficultGroup> _repository;
    private readonly IMapper _mapper;

    public GetAllDifficultGroupsQueryHandler(
        IRepository<DifficultGroup> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<DifficultGroupDto>> Handle(
        GetAllDifficultGroupsQuery request,
        CancellationToken cancellationToken)
    {
        var groups = await _repository.GetAllAsync();
        return _mapper.Map<List<DifficultGroupDto>>(groups);
    }
}
