using AutoMapper;
using Backer.Application.Features.HardwareCartReaders.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareCartReaders.Queries;

public record GetAllHardwareCartReadersQuery : IRequest<List<HardwareCartReaderDto>>;

public class GetAllHardwareCartReadersQueryHandler : IRequestHandler<GetAllHardwareCartReadersQuery, List<HardwareCartReaderDto>>
{
    private readonly IRepository<HardwareCartReader> _repository;
    private readonly IMapper _mapper;

    public GetAllHardwareCartReadersQueryHandler(IRepository<HardwareCartReader> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<HardwareCartReaderDto>> Handle(GetAllHardwareCartReadersQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<HardwareCartReaderDto>>(entities);
    }
}
