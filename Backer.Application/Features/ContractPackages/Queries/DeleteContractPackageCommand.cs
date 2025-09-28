using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.ContractPackages.Queries;

public record DeleteContractPackageCommand(int Id) : IRequest<bool>;

public class DeleteContractPackageCommandHandler : IRequestHandler<DeleteContractPackageCommand, bool>
{
    private readonly IRepository<ContractPackage> _repository;

    public DeleteContractPackageCommandHandler(IRepository<ContractPackage> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteContractPackageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}