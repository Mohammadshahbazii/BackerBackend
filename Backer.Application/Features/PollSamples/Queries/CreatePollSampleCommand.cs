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

public record CreatePollSampleCommand(CreatePollSampleDto Dto) : IRequest<int>;

public class CreatePollSampleCommandHandler : IRequestHandler<CreatePollSampleCommand, int>
{
    private readonly IRepository<PollSample> _repository;

    public CreatePollSampleCommandHandler(IRepository<PollSample> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreatePollSampleCommand request, CancellationToken ct)
    {
        var entity = new PollSample
        {
            Name = request.Dto.name,
            JobTitleId = request.Dto.jobTitleId
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}