using Backer.Application.Features.DifficultGroups.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.DifficultGroups.Queries;

public record UpdateDifficultGroupCommand(UpdateDifficultGroupDto Dto) : IRequest<bool>;

public class UpdateDifficultGroupCommandHandler : IRequestHandler<UpdateDifficultGroupCommand, bool>
{
    private readonly IRepository<DifficultGroup> _repository;

    public UpdateDifficultGroupCommandHandler(IRepository<DifficultGroup> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateDifficultGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        await _repository.UpdateAsync(entity);
        return true;
    }
}

