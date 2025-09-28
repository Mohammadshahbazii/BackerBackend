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

public record CreateContractPackageCommand(CreateContractPackageDto Dto) : IRequest<int>;

public class CreateContractPackageCommandHandler : IRequestHandler<CreateContractPackageCommand, int>
{
    private readonly IRepository<ContractPackage> _repository;
    private readonly IMapper _mapper;

    public CreateContractPackageCommandHandler(IRepository<ContractPackage> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateContractPackageCommand request, CancellationToken cancellationToken)
    {
        var entity = new ContractPackage
        {
            Title = request.Dto.Title,
            Description = request.Dto.Description
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
