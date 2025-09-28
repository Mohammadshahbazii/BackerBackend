using AutoMapper;
using Backer.Application.Features.DeviceContractSamplePrices.Dtos;
using Backer.Core.Interfaces;
using MediatR;
using Backer.Core.Entities;

namespace Backer.Application.Features.DeviceContractSamplePrices.Queries;

public record GetPriceByIdQuery(int Id) : IRequest<DeviceContractSamplePriceDto>;

public class GetPriceByIdQueryHandler
    : IRequestHandler<GetPriceByIdQuery, DeviceContractSamplePriceDto>
{
    private readonly IRepository<DeviceContractSamplePrice> _repository;
    private readonly IMapper _mapper;

    public GetPriceByIdQueryHandler(
        IRepository<DeviceContractSamplePrice> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeviceContractSamplePriceDto> Handle(
        GetPriceByIdQuery request,
        CancellationToken ct)
    {
        var price = await _repository.GetByIdWithIncludeAsync(
            request.Id,
            p => p.DeviceContractSample);

        return _mapper.Map<DeviceContractSamplePriceDto>(price);
    }
}