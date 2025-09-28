using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwarePortals.Queries;

public record DeleteHardwarePortalCommand(int Id) : IRequest<bool>;

public class DeleteHardwarePortalCommandHandler : IRequestHandler<DeleteHardwarePortalCommand, bool>
{
    private readonly IRepository<HardwarePortal> _repository;

    public DeleteHardwarePortalCommandHandler(IRepository<HardwarePortal> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteHardwarePortalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}