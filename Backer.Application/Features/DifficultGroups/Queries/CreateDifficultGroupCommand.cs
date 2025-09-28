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

public record CreateDifficultGroupCommand(CreateDifficultGroupDto Dto) : IRequest<int>;


public class CreateDifficultGroupCommandHandler : IRequestHandler<CreateDifficultGroupCommand, int>
{
    private readonly IRepository<DifficultGroup> _repository;

    public CreateDifficultGroupCommandHandler(IRepository<DifficultGroup> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateDifficultGroupCommand request, CancellationToken cancellationToken)
    {
        var entity = new DifficultGroup { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
