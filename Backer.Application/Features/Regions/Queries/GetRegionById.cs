using AutoMapper;
using Backer.Application.Features.Regions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.Regions.Queries;

public record GetRegionByIdQuery(int Id) : IRequest<RegionDto>;

public class GetRegionByIdQueryHandler
    : IRequestHandler<GetRegionByIdQuery, RegionDto>
{
    private readonly IRepository<Region> _repository;
    private readonly IMapper _mapper;

    public GetRegionByIdQueryHandler(IRepository<Region> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<RegionDto> Handle(GetRegionByIdQuery request, CancellationToken ct)
    {
        var region = await _repository.GetByIdWithIncludeAsync(
            request.Id,
            r => r.Parent); // Include Parent data

        return _mapper.Map<RegionDto>(region);
    }
}