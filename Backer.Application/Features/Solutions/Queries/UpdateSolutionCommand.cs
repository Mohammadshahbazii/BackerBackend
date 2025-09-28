using Backer.Application.Features.Solutions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Solutions.Queries;

public record UpdateSolutionCommand(UpdateSolutionDto Dto) : IRequest<bool>;

public class UpdateSolutionCommandHandler : IRequestHandler<UpdateSolutionCommand, bool>
{
    private readonly IRepository<Solution> _repository;

    public UpdateSolutionCommandHandler(IRepository<Solution> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateSolutionCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;
        entity.Description = request.Dto.Description;
        await _repository.UpdateAsync(entity);
        return true;
    }
}
