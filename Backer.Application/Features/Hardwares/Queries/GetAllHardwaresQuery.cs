using AutoMapper;
using Backer.Application.Features.Hardwares.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Hardwares.Queries;

public record GetAllHardwaresQuery : IRequest<List<HardwareDto>>;

public class GetAllHardwaresQueryHandler : IRequestHandler<GetAllHardwaresQuery, List<HardwareDto>>
{
    private readonly IRepository<Hardware> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwaresQueryHandler(IRepository<Hardware> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwareDto>> Handle(GetAllHardwaresQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwareDto>>(entities);
    }
}