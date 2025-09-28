using AutoMapper;
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

public record GetRegionsByParentIdQuery(int ParentId) : IRequest<IEnumerable<RegionDto>>;

public class GetRegionsByParentIdQueryHandler
    : IRequestHandler<GetRegionsByParentIdQuery, IEnumerable<RegionDto>>
{
    private readonly IRepository<Region> _repository;
    private readonly IMapper _mapper;

    public GetRegionsByParentIdQueryHandler(IRepository<Region> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RegionDto>> Handle(GetRegionsByParentIdQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.Table
            .Where(r => r.ParentId == request.ParentId)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<RegionDto>>(entities);
    }
}
