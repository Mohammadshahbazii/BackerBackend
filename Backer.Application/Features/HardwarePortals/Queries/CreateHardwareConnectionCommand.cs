using Backer.Application.Features.HardwarePortals.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwarePortals.Queries;


public record CreateHardwarePortalCommand(CreateHardwarePortalDto Dto) : IRequest<int>;

public class CreateHardwarePortalCommandHandler : IRequestHandler<CreateHardwarePortalCommand, int>
{
    private readonly IRepository<HardwarePortal> _repository;

    public CreateHardwarePortalCommandHandler(IRepository<HardwarePortal> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateHardwarePortalCommand request, CancellationToken cancellationToken)
    {
        var entity = new HardwarePortal { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}

