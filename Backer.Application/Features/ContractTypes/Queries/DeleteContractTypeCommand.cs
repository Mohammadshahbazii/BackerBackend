using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.ContractTypes.Queries;

public record DeleteContractTypeCommand(int Id) : IRequest<bool>;

public class DeleteContractTypeCommandHandler : IRequestHandler<DeleteContractTypeCommand, bool>
{
    private readonly IRepository<ContractType> _repository;

    public DeleteContractTypeCommandHandler(IRepository<ContractType> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteContractTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}