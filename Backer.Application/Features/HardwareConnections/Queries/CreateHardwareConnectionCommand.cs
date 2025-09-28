using Backer.Application.Features.HardwareConnections.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareConnections.Queries;

public record CreateHardwareConnectionCommand(CreateHardwareConnectionDto Dto) : IRequest<int>;

public class CreateHardwareConnectionCommandHandler : IRequestHandler<CreateHardwareConnectionCommand, int>
{
    private readonly IRepository<HardwareConnection> _repository;

    public CreateHardwareConnectionCommandHandler(IRepository<HardwareConnection> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateHardwareConnectionCommand request, CancellationToken cancellationToken)
    {
        var entity = new HardwareConnection { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
