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

public record UpdateHardwareReplaceCommand(UpdateHardwareReplaceDto Dto) : IRequest<bool>;

public class UpdateHardwareReplaceCommandHandler : IRequestHandler<UpdateHardwareReplaceCommand, bool>
{
    private readonly IRepository<HardwareReplace> _repository;

    public UpdateHardwareReplaceCommandHandler(IRepository<HardwareReplace> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateHardwareReplaceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        await _repository.UpdateAsync(entity);
        return true;
    }
}
