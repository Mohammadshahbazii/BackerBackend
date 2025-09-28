using AutoMapper;
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

public record GetAllContractPackagesQuery : IRequest<List<ContractPackageDto>>;

public class GetAllContractPackagesQueryHandler : IRequestHandler<GetAllContractPackagesQuery, List<ContractPackageDto>>
{
    private readonly IRepository<ContractPackage> _repository;
    private readonly IMapper _mapper;

    public GetAllContractPackagesQueryHandler(IRepository<ContractPackage> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ContractPackageDto>> Handle(GetAllContractPackagesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<ContractPackageDto>>(entities);
    }
}