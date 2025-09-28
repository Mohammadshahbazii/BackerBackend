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
public record GetAllContractTypesQuery : IRequest<List<ContractTypeDto>>;

public class GetAllContractTypesQueryHandler : IRequestHandler<GetAllContractTypesQuery, List<ContractTypeDto>>
{
    private readonly IRepository<ContractType> _repository;
    private readonly IMapper _mapper;

    public GetAllContractTypesQueryHandler(IRepository<ContractType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ContractTypeDto>> Handle(GetAllContractTypesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<ContractTypeDto>>(entities);
    }
}