using AutoMapper;
using Backer.Application.Features.ContractTypes.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.ContractTypes.Queries;

public record GetContractTypeByIdQuery(int Id) : IRequest<ContractTypeDto>;

public class GetContractTypeByIdQueryHandler
    : IRequestHandler<GetContractTypeByIdQuery, ContractTypeDto>
{
    private readonly IRepository<ContractType> _repository;
    private readonly IMapper _mapper;

    public GetContractTypeByIdQueryHandler(IRepository<ContractType> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ContractTypeDto> Handle(GetContractTypeByIdQuery request, CancellationToken ct)
    {
        var contractType = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<ContractTypeDto>(contractType);
    }
}