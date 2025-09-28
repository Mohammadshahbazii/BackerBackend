using Backer.Application.Features.HardwareConnections.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareConnections.Queries;

public record UpdateHardwareConnectionCommand(UpdateHardwareConnectionDto Dto) : IRequest<bool>;

public class UpdateHardwareConnectionCommandHandler : IRequestHandler<UpdateHardwareConnectionCommand, bool>
{
    private readonly IRepository<HardwareConnection> _repository;

    public UpdateHardwareConnectionCommandHandler(IRepository<HardwareConnection> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateHardwareConnectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        await _repository.UpdateAsync(entity);
        return true;
    }
}
