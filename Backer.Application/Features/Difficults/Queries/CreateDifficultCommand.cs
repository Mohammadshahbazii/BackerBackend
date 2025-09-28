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

public record CreateDifficultCommand(CreateDifficultDto Dto) : IRequest<int>;

public class CreateDifficultCommandHandler : IRequestHandler<CreateDifficultCommand, int>
{
    private readonly IRepository<Difficult> _repository;

    public CreateDifficultCommandHandler(IRepository<Difficult> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateDifficultCommand request, CancellationToken ct)
    {
        var entity = new Difficult
        {
            Description = request.Dto.Description,
            DifficultGroupId = request.Dto.DifficultGroupId
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}