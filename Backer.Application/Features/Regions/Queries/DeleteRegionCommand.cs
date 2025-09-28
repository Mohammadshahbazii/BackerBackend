using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Regions.Queries;

public record DeleteRegionCommand(int Id) : IRequest<bool>;

public class DeleteRegionCommandHandler : IRequestHandler<DeleteRegionCommand , bool>
{
    private readonly IRepository<Region> _repository;

    public DeleteRegionCommandHandler(IRepository<Region> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
            return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
