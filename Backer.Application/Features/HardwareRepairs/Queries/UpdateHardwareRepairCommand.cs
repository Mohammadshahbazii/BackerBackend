using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareRepairs.Queries;


public record UpdateHardwareRepairCommand(UpdateHardwareRepairDto Dto) : IRequest<bool>;

public class UpdateHardwareRepairCommandHandler : IRequestHandler<UpdateHardwareRepairCommand, bool>
{
    private readonly IRepository<HardwareRepair> _repository;

    public UpdateHardwareRepairCommandHandler(IRepository<HardwareRepair> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateHardwareRepairCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        await _repository.UpdateAsync(entity);
        return true;
    }
}