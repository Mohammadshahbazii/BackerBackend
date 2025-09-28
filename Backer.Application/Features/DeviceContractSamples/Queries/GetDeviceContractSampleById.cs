using AutoMapper;
using Backer.Application.Features.DeviceContractSamples.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.DeviceContractSamples.Queries;

public record GetDeviceContractSampleByIdQuery(int Id) : IRequest<DeviceContractSampleDto>;

public class GetDeviceContractSampleByIdQueryHandler
    : IRequestHandler<GetDeviceContractSampleByIdQuery, DeviceContractSampleDto>
{
    private readonly IRepository<DeviceContractSample> _repository;
    private readonly IMapper _mapper;

    public GetDeviceContractSampleByIdQueryHandler(
        IRepository<DeviceContractSample> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeviceContractSampleDto> Handle(
        GetDeviceContractSampleByIdQuery request,
        CancellationToken ct)
    {
        var sample = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<DeviceContractSampleDto>(sample);
    }
}