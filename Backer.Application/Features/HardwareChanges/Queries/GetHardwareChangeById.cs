using AutoMapper;
using Backer.Application.Features.HardwareChanges.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.HardwareChanges.Queries;

public record GetHardwareChangeByIdQuery(int Id) : IRequest<HardwareChangeDto>;

public class GetHardwareChangeByIdQueryHandler
    : IRequestHandler<GetHardwareChangeByIdQuery, HardwareChangeDto>
{
    private readonly IRepository<HardwareChange> _repository;
    private readonly IMapper _mapper;

    public GetHardwareChangeByIdQueryHandler(
        IRepository<HardwareChange> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwareChangeDto> Handle(
        GetHardwareChangeByIdQuery request,
        CancellationToken ct)
    {
        var connection = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwareChangeDto>(connection);
    }
}