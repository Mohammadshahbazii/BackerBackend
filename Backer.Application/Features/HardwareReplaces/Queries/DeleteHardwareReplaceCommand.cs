using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareReplaces.Queries;

public record DeleteHardwareReplaceCommand(int Id) : IRequest<bool>;

public class DeleteHardwareReplaceCommandHandler : IRequestHandler<DeleteHardwareReplaceCommand, bool>
{ 
    private readonly IRepository<HardwareReplace> _repository;

    public DeleteHardwareReplaceCommandHandler(IRepository<HardwareReplace> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteHardwareReplaceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}