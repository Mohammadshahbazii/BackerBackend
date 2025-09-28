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

public record UpdateHardwareCommand(UpdateHardwareDto Dto) : IRequest<bool>;

public class UpdateHardwareCommandHandler : IRequestHandler<UpdateHardwareCommand, bool>
{
    private readonly IRepository<Hardware> _repository;

    public UpdateHardwareCommandHandler(IRepository<Hardware> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateHardwareCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.ModelName = request.Dto.ModelName;
        entity.IsActive = request.Dto.IsActive;

        await _repository.UpdateAsync(entity);
        return true;
    }
}
