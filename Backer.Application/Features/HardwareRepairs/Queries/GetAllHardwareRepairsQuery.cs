using AutoMapper;
using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareRepairs.Queries;

public record GetAllHardwareRepairsQuery : IRequest<List<HardwareRepairDto>>;

public class GetAllHardwareRepairsQueryHandler : IRequestHandler<GetAllHardwareRepairsQuery, List<HardwareRepairDto>>
{
    private readonly IRepository<HardwareRepair> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwareRepairsQueryHandler(IRepository<HardwareRepair> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwareRepairDto>> Handle(GetAllHardwareRepairsQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwareRepairDto>>(items);
    }
}