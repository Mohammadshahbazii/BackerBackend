using AutoMapper;
using Backer.Application.Features.ContractPackages.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.ContractPackages.Queries;

public record GetContractPackageByIdQuery(int Id) : IRequest<ContractPackageDto>;

public class GetContractPackageByIdQueryHandler
    : IRequestHandler<GetContractPackageByIdQuery, ContractPackageDto>
{
    private readonly IRepository<ContractPackage> _repository;
    private readonly IMapper _mapper;

    public GetContractPackageByIdQueryHandler(IRepository<ContractPackage> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ContractPackageDto> Handle(GetContractPackageByIdQuery request, CancellationToken ct)
    {
        var package = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<ContractPackageDto>(package);
    }
}