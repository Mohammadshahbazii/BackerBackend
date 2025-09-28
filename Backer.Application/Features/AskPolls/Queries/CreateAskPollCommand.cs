using Backer.Application.Features.AskPolls.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.AskPolls.Queries;

public record CreateAskPollCommand(CreateAskPollDto Dto) : IRequest<int>;

public class CreateAskPollCommandHandler : IRequestHandler<CreateAskPollCommand, int>
{
    private readonly IRepository<AskPoll> _repository;

    public CreateAskPollCommandHandler(IRepository<AskPoll> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateAskPollCommand request, CancellationToken cancellationToken)
    {
        var entity = new AskPoll { Description = request.Dto.Description };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}