using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Solutions.Queries;

public record DeleteSolutionCommand(int Id) : IRequest<bool>;

public class DeleteSolutionCommandHandler : IRequestHandler<DeleteSolutionCommand, bool>
{
    private readonly IRepository<Solution> _repository;

    public DeleteSolutionCommandHandler(IRepository<Solution> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteSolutionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}