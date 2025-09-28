using AutoMapper;
using Backer.Application.Features.AccessGroups.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.AccessGroups.Queries;

public record GetAccessGroupByIdQuery(int Id) : IRequest<AccessGroupDto>;

public class GetAccessGroupByIdQueryHandler
    : IRequestHandler<GetAccessGroupByIdQuery, AccessGroupDto>
{
    private readonly IRepository<AccessGroup> _repository;
    private readonly IMapper _mapper;

    public GetAccessGroupByIdQueryHandler(
        IRepository<AccessGroup> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AccessGroupDto> Handle(
        GetAccessGroupByIdQuery request,
        CancellationToken ct)
    {
        var group = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<AccessGroupDto>(group);
    }
}