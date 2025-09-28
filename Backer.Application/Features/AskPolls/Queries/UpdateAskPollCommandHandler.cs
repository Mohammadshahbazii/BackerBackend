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

public record UpdateAskPollCommand(UpdateAskPollDto Dto) : IRequest<bool>;

public class UpdateAskPollCommandHandler : IRequestHandler<UpdateAskPollCommand, bool>
{
    private readonly IRepository<AskPoll> _repository;

    public UpdateAskPollCommandHandler(IRepository<AskPoll> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateAskPollCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Description = request.Dto.Description;
        await _repository.UpdateAsync(entity);
        return true;
    }
}
