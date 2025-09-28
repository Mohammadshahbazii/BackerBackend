using Backer.Application.Features.PollSamples.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.PollSamples.Queries;

public record UpdatePollSampleCommand(UpdatePollSampleDto Dto) : IRequest<bool>;

public class UpdatePollSampleCommandHandler : IRequestHandler<UpdatePollSampleCommand, bool>
{
    private readonly IRepository<PollSample> _repository;

    public UpdatePollSampleCommandHandler(IRepository<PollSample> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdatePollSampleCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Name = request.Dto.Name;
        entity.JobTitleId = request.Dto.JobTitleId;

        await _repository.UpdateAsync(entity);
        return true;
    }
}