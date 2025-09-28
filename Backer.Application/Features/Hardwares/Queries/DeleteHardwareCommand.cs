using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Hardwares.Queries;

public record DeleteHardwareCommand(int Id) : IRequest<bool>;

public class DeleteHardwareCommandHandler : IRequestHandler<DeleteHardwareCommand, bool>
{
    private readonly IRepository<Hardware> _repository;

    public DeleteHardwareCommandHandler(IRepository<Hardware> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteHardwareCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}