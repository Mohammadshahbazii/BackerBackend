using AutoMapper;
using Backer.Application.Features.PollSamples.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.PollSamples.Queries;

public record GetPollSampleByIdQuery(int Id) : IRequest<PollSampleDto>;

public class GetPollSampleByIdQueryHandler
    : IRequestHandler<GetPollSampleByIdQuery, PollSampleDto>
{
    private readonly IRepository<PollSample> _repository;
    private readonly IMapper _mapper;

    public GetPollSampleByIdQueryHandler(
        IRepository<PollSample> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PollSampleDto> Handle(
        GetPollSampleByIdQuery request,
        CancellationToken ct)
    {
        var pollSample = await _repository.GetByIdWithIncludeAsync(
            request.Id,
            p => p.JobTitle); // Include JobTitle

        return _mapper.Map<PollSampleDto>(pollSample);
    }
}