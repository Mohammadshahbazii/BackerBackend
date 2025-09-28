using AutoMapper;
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

public record CreateContractTypeCommand(CreateContractTypeDto Dto) : IRequest<int>;

public class CreateContractTypeCommandHandler : IRequestHandler<CreateContractTypeCommand, int>
{
    private readonly IRepository<ContractType> _repository;
    private readonly IMapper _mapper;

    public CreateContractTypeCommandHandler(IRepository<ContractType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateContractTypeCommand request, CancellationToken cancellationToken)
    {
        var entity = new ContractType
        {
            Name = request.Dto.Name,
            CallCount = request.Dto.CallCount,
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}