using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backer.Application.Features.PollSamples.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.PollSamples.Queries;
public record GetAllPollSamplesQuery : IRequest<List<PollSampleDto>>;

public class GetAllPollSamplesQueryHandler : IRequestHandler<GetAllPollSamplesQuery, List<PollSampleDto>>
{
    private readonly IRepository<PollSample> _repository;
    private readonly IMapper _mapper;

    public GetAllPollSamplesQueryHandler(IRepository<PollSample> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<PollSampleDto>> Handle(GetAllPollSamplesQuery request, CancellationToken cancellationToken)
    {
        var PollSamples = await _repository.Table
            .Include(d => d.JobTitle)
            .ProjectTo<PollSampleDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return PollSamples;
    }
}
