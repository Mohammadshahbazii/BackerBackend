using AutoMapper;
using Backer.Application.Features.AskPolls.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.AskPolls.Queries;

public record GetAskPollByIdQuery(int Id) : IRequest<AskPollDto>;

public class GetAskPollByIdQueryHandler
    : IRequestHandler<GetAskPollByIdQuery, AskPollDto>
{
    private readonly IRepository<AskPoll> _repository;
    private readonly IMapper _mapper;

    public GetAskPollByIdQueryHandler(
        IRepository<AskPoll> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AskPollDto> Handle(
        GetAskPollByIdQuery request,
        CancellationToken ct)
    {
        var askPoll = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<AskPollDto>(askPoll);
    }
}