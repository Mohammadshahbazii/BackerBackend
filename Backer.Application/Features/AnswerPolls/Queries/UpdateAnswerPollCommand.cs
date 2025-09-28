using Backer.Application.Features.AnswerPolls.Dtos;
using Backer.Application.Features.AskPolls.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.AnswerPolls.Queries;

public record UpdateAnswerPollCommand(UpdateAnswerPollDto Dto) : IRequest<bool>;

public class UpdateAnswerPollCommandHandler : IRequestHandler<UpdateAnswerPollCommand, bool>
{
    private readonly IRepository<AnswerPoll> _repository;

    public UpdateAnswerPollCommandHandler(IRepository<AnswerPoll> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateAnswerPollCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Description = request.Dto.Description;
        await _repository.UpdateAsync(entity);
        return true;
    }
}
