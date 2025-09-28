using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.PollSamples.Queries;

public record DeletePollSampleCommand(int Id) : IRequest<bool>;

public class DeletePollSampleCommandHandler : IRequestHandler<DeletePollSampleCommand, bool>
{
    private readonly IRepository<PollSample> _repository;

    public DeletePollSampleCommandHandler(IRepository<PollSample> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeletePollSampleCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
