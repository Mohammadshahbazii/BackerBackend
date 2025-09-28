using AutoMapper;
using Backer.Application.Features.HardwarePortals.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.HardwarePortals.Queries;

public record GetHardwarePortalByIdQuery(int Id) : IRequest<HardwarePortalDto>;

public class GetHardwarePortalByIdQueryHandler
    : IRequestHandler<GetHardwarePortalByIdQuery, HardwarePortalDto>
{
    private readonly IRepository<HardwarePortal> _repository;
    private readonly IMapper _mapper;

    public GetHardwarePortalByIdQueryHandler(
        IRepository<HardwarePortal> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwarePortalDto> Handle(
        GetHardwarePortalByIdQuery request,
        CancellationToken ct)
    {
        var portal = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwarePortalDto>(portal);
    }
}