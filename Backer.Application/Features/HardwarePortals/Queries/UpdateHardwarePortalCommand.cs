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

public record UpdateHardwarePortalCommand(UpdateHardwarePortalDto Dto) : IRequest<bool>;

public class UpdateHardwarePortalCommandHandler : IRequestHandler<UpdateHardwarePortalCommand, bool>
{
    private readonly IRepository<HardwarePortal> _repository;

    public UpdateHardwarePortalCommandHandler(IRepository<HardwarePortal> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateHardwarePortalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        await _repository.UpdateAsync(entity);
        return true;
    }
}