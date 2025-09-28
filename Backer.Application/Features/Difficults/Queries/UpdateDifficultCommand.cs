using Backer.Application.Features.Difficults.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Difficults.Queries;

public record UpdateDifficultCommand(UpdateDifficultDto Dto) : IRequest<bool>;

public class UpdateDifficultCommandHandler : IRequestHandler<UpdateDifficultCommand, bool>
{
    private readonly IRepository<Difficult> _repository;

    public UpdateDifficultCommandHandler(IRepository<Difficult> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateDifficultCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Description = request.Dto.Description;
        entity.DifficultGroupId = request.Dto.DifficultGroupId;

        await _repository.UpdateAsync(entity);
        return true;
    }
}

