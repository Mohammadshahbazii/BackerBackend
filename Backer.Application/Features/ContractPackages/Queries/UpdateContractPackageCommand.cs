using Backer.Application.Features.ContractPackages.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.ContractPackages.Queries;

public record UpdateContractPackageCommand(UpdateContractPackageDto Dto) : IRequest<bool>;

public class UpdateContractPackageCommandHandler : IRequestHandler<UpdateContractPackageCommand, bool>
{
    private readonly IRepository<ContractPackage> _repository;

    public UpdateContractPackageCommandHandler(IRepository<ContractPackage> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateContractPackageCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        entity.Description = request.Dto.Description;

        await _repository.UpdateAsync(entity);
        return true;
    }
}
