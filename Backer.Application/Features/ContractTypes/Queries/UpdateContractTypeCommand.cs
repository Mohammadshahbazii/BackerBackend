using Backer.Application.Features.ContractTypes.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.ContractTypes.Queries;

public record UpdateContractTypeCommand(UpdateContractTypeDto Dto) : IRequest<bool>;

public class UpdateContractTypeCommandHandler : IRequestHandler<UpdateContractTypeCommand, bool>
{
    private readonly IRepository<ContractType> _repository;

    public UpdateContractTypeCommandHandler(IRepository<ContractType> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateContractTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Name = request.Dto.Name;
        entity.CallCount = request.Dto.CallCount;

        await _repository.UpdateAsync(entity);
        return true;
    }
}
