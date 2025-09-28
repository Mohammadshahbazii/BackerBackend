using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Difficults.Queries;

public record DeleteDifficultCommand(int Id) : IRequest<bool>;

public class DeleteDifficultCommandHandler : IRequestHandler<DeleteDifficultCommand, bool>
{
    private readonly IRepository<Difficult> _repository;

    public DeleteDifficultCommandHandler(IRepository<Difficult> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteDifficultCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
