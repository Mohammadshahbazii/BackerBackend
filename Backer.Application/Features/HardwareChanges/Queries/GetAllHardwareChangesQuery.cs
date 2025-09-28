using AutoMapper;
using Backer.Application.Features.HardwareChanges.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareChanges.Queries;

public record GetAllHardwareChangesQuery : IRequest<List<HardwareChangeDto>>;

public class GetAllHardwareChangesQueryHandler : IRequestHandler<GetAllHardwareChangesQuery, List<HardwareChangeDto>>
{
    private readonly IRepository<HardwareChange> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwareChangesQueryHandler(IRepository<HardwareChange> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwareChangeDto>> Handle(GetAllHardwareChangesQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwareChangeDto>>(items);
    }
}
