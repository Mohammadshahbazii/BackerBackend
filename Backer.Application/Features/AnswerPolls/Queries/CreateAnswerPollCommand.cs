using Backer.Application.Features.AnswerPolls.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.AnswerPolls.Queries;

public record CreateAnswerPollCommand(CreateAnswerPollDto Dto) : IRequest<int>;

public class CreateAnswerPollCommandHandler : IRequestHandler<CreateAnswerPollCommand, int>
{
    private readonly IRepository<AnswerPoll> _repository;

    public CreateAnswerPollCommandHandler(IRepository<AnswerPoll> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateAnswerPollCommand request, CancellationToken cancellationToken)
    {
        var entity = new AnswerPoll { Description = request.Dto.Description };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
