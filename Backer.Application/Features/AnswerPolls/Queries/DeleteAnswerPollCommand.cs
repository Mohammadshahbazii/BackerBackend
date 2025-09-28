using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.AnswerPolls.Queries;

public record DeleteAnswerPollCommand(int Id) : IRequest<bool>;

public class DeleteAnswerPollCommandHandler : IRequestHandler<DeleteAnswerPollCommand, bool>
{
    private readonly IRepository<AnswerPoll> _repository;

    public DeleteAnswerPollCommandHandler(IRepository<AnswerPoll> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteAnswerPollCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}