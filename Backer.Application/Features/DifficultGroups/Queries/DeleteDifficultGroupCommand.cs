using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.DifficultGroups.Queries;

public record DeleteDifficultGroupCommand(int Id) : IRequest<bool>;

public class DeleteDifficultGroupCommandHandler : IRequestHandler<DeleteDifficultGroupCommand, bool>
{
    private readonly IRepository<DifficultGroup> _repository;

    public DeleteDifficultGroupCommandHandler(IRepository<DifficultGroup> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteDifficultGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
