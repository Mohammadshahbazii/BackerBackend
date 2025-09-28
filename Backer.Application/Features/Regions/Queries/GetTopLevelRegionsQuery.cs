using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backer.Application.Features.PollSamples.Dtos;
using Backer.Application.Features.Regions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Regions.Queries;

public record GetTopLevelRegionsQuery : IRequest<IEnumerable<RegionDto>>;

public class GetTopLevelRegionsQueryHandler
    : IRequestHandler<GetTopLevelRegionsQuery, IEnumerable<RegionDto>>
{
    private readonly IRepository<Region> _repository;
    private readonly IMapper _mapper;

    public GetTopLevelRegionsQueryHandler(IRepository<Region> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RegionDto>> Handle(GetTopLevelRegionsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.Table
            .Where(r => r.ParentId == null)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<RegionDto>>(entities);
    }
}