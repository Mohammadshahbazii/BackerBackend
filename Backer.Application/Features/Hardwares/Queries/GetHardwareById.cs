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

public record GetHardwareByIdQuery(int Id) : IRequest<HardwareDto>;

public class GetHardwareByIdQueryHandler
    : IRequestHandler<GetHardwareByIdQuery, HardwareDto>
{
    private readonly IRepository<Hardware> _repository;
    private readonly IMapper _mapper;

    public GetHardwareByIdQueryHandler(
        IRepository<Hardware> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwareDto> Handle(
        GetHardwareByIdQuery request,
        CancellationToken ct)
    {
        var hardware = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwareDto>(hardware);
    }
}
