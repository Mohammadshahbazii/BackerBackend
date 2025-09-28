using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareRepairs.Queries;

public record CreateHardwareRepairCommand(CreateHardwareRepairDto Dto) : IRequest<int>;

public class CreateHardwareRepairCommandHandler : IRequestHandler<CreateHardwareRepairCommand, int>
{
    private readonly IRepository<HardwareRepair> _repository;

    public CreateHardwareRepairCommandHandler(IRepository<HardwareRepair> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateHardwareRepairCommand request, CancellationToken cancellationToken)
    {
        var entity = new HardwareRepair { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
