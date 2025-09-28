using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Software.Queries;

public record DeleteSoftwareCommand(int Id) : IRequest<bool>;

public class DeleteSoftwareCommandHandler : IRequestHandler<DeleteSoftwareCommand, bool>
{
    private readonly IRepository<Backer.Core.Entities.Software> _repository;

    public DeleteSoftwareCommandHandler(IRepository<Backer.Core.Entities.Software> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteSoftwareCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}