using AutoMapper;
using Backer.Application.Features.HardwareReplaces.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.HardwareReplaces.Queries;

public record GetHardwareReplaceByIdQuery(int Id) : IRequest<HardwareReplaceDto>;

public class GetHardwareReplaceByIdQueryHandler
    : IRequestHandler<GetHardwareReplaceByIdQuery, HardwareReplaceDto>
{
    private readonly IRepository<HardwareReplace> _repository;
    private readonly IMapper _mapper;

    public GetHardwareReplaceByIdQueryHandler(IRepository<HardwareReplace> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwareReplaceDto> Handle(GetHardwareReplaceByIdQuery request, CancellationToken ct)
    {
        var item = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwareReplaceDto>(item);
    }
}