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

public record CreateSolutionCommand(CreateSolutionDto Dto) : IRequest<int>;

public class CreateSolutionCommandHandler : IRequestHandler<CreateSolutionCommand, int>
{
    private readonly IRepository<Solution> _repository;

    public CreateSolutionCommandHandler(IRepository<Solution> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateSolutionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Solution { Title = request.Dto.Title , Description = request.Dto.Description };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}