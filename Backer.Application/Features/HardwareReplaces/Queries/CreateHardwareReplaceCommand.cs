using Backer.Application.Features.HardwareReplaces.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareReplaces.Queries;

public record CreateHardwareReplaceCommand(CreateHardwareReplaceDto Dto) : IRequest<int>;

public class CreateHardwareReplaceCommandHandler : IRequestHandler<CreateHardwareReplaceCommand, int>
{
    private readonly IRepository<HardwareReplace> _repository;

    public CreateHardwareReplaceCommandHandler(IRepository<HardwareReplace> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateHardwareReplaceCommand request, CancellationToken cancellationToken)
    {
        var entity = new HardwareReplace { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
