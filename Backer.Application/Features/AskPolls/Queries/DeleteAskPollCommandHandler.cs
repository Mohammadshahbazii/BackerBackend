using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.AskPolls.Queries;

public record DeleteAskPollCommand(int Id) : IRequest<bool>;

public class DeleteAskPollCommandHandler : IRequestHandler<DeleteAskPollCommand, bool>
{
    private readonly IRepository<AskPoll> _repository;

    public DeleteAskPollCommandHandler(IRepository<AskPoll> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteAskPollCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
