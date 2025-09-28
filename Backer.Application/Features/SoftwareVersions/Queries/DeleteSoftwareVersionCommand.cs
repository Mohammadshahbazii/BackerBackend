using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.SoftwareVersions.Queries;

public record DeleteSoftwareVersionCommand(int Id) : IRequest<bool>;

public class DeleteSoftwareVersionCommandHandler : IRequestHandler<DeleteSoftwareVersionCommand, bool>
{
    private readonly IRepository<SoftwareVersion> _repository;

    public DeleteSoftwareVersionCommandHandler(IRepository<SoftwareVersion> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteSoftwareVersionCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}