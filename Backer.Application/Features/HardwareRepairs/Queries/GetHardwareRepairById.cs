using AutoMapper;
using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.HardwareRepairs.Queries;

public record GetHardwareRepairByIdQuery(int Id) : IRequest<HardwareRepairDto>;

public class GetHardwareRepairByIdQueryHandler
    : IRequestHandler<GetHardwareRepairByIdQuery, HardwareRepairDto>
{
    private readonly IRepository<HardwareRepair> _repository;
    private readonly IMapper _mapper;

    public GetHardwareRepairByIdQueryHandler(
        IRepository<HardwareRepair> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwareRepairDto> Handle(
        GetHardwareRepairByIdQuery request,
        CancellationToken ct)
    {
        var connection = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwareRepairDto>(connection);
    }
}