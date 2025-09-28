using AutoMapper;
using Backer.Application.Features.HardwareConnections.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareConnections.Queries;

public record GetAllHardwareConnectionsQuery : IRequest<List<HardwareConnectionDto>>;

public class GetAllHardwareConnectionsQueryHandler : IRequestHandler<GetAllHardwareConnectionsQuery, List<HardwareConnectionDto>>
{
    private readonly IRepository<HardwareConnection> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwareConnectionsQueryHandler(IRepository<HardwareConnection> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwareConnectionDto>> Handle(GetAllHardwareConnectionsQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwareConnectionDto>>(items);
    }
}

