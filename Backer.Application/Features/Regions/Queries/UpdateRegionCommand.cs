using AutoMapper;
using Backer.Application.Features.JobTitles.Queries;
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

public record UpdateRegionCommand(UpdateRegionDto Dto) : IRequest<bool>;

public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand, bool>
{
    private readonly IRepository<Region> _repository;
    private readonly IMapper _mapper;

    public UpdateRegionCommandHandler(IRepository<Region> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        entity.ParentId = request.Dto.ParentId;

        await _repository.UpdateAsync(entity);
        return true;
    }
}
