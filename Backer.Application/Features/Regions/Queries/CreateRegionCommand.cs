using AutoMapper;
using Backer.Application.Features.Regions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Regions.Queries;

public record CreateRegionCommand(CreateRegionDto Dto) : IRequest<int>;

public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, int>
{
    private readonly IRepository<Region> _repository;
    private readonly IMapper _mapper;

    public CreateRegionCommandHandler(IRepository<Region> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Region>(request.Dto);
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}