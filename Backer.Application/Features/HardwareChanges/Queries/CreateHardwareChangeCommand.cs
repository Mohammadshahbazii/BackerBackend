using Backer.Application.Features.HardwareChanges.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareChanges.Queries;

public record CreateHardwareChangeCommand(CreateHardwareChangeDto Dto) : IRequest<int>;

public class CreateHardwareChangeCommandHandler : IRequestHandler<CreateHardwareChangeCommand, int>
{
    private readonly IRepository<HardwareChange> _repository;

    public CreateHardwareChangeCommandHandler(IRepository<HardwareChange> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateHardwareChangeCommand request, CancellationToken cancellationToken)
    {
        var entity = new HardwareChange { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
