using AutoMapper;
using Backer.Application.Features.HardwarePortals.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwarePortals.Queries;

public record GetAllHardwarePortalsQuery : IRequest<List<HardwarePortalDto>>;

public class GetAllHardwarePortalsQueryHandler : IRequestHandler<GetAllHardwarePortalsQuery, List<HardwarePortalDto>>
{
    private readonly IRepository<HardwarePortal> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwarePortalsQueryHandler(IRepository<HardwarePortal> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwarePortalDto>> Handle(GetAllHardwarePortalsQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwarePortalDto>>(items);
    }
}