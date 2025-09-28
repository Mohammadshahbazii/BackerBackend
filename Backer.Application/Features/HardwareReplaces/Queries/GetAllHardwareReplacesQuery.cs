using AutoMapper;
using Backer.Application.Features.HardwareReplaces.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareReplaces.Queries;

public record GetAllHardwareReplacesQuery : IRequest<List<HardwareReplaceDto>>;

public class GetAllHardwareReplacesQueryHandler : IRequestHandler<GetAllHardwareReplacesQuery, List<HardwareReplaceDto>>
{
    private readonly IRepository<HardwareReplace> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwareReplacesQueryHandler(IRepository<HardwareReplace> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwareReplaceDto>> Handle(GetAllHardwareReplacesQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwareReplaceDto>>(items);
    }
}