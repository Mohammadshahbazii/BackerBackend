using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareConnections.Queries;

public record DeleteHardwareConnectionCommand(int Id) : IRequest<bool>;

public class DeleteHardwareConnectionCommandHandler : IRequestHandler<DeleteHardwareConnectionCommand, bool>
{
    private readonly IRepository<HardwareConnection> _repository;

    public DeleteHardwareConnectionCommandHandler(IRepository<HardwareConnection> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteHardwareConnectionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
