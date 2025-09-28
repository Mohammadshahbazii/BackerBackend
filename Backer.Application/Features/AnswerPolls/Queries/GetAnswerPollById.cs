using AutoMapper;
using Backer.Application.Features.AnswerPolls.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.AnswerPolls.Queries;

public record GetAnswerPollByIdQuery(int Id) : IRequest<AnswerPollDto>;

public class GetAnswerPollByIdQueryHandler
    : IRequestHandler<GetAnswerPollByIdQuery, AnswerPollDto>
{
    private readonly IRepository<AnswerPoll> _repository;
    private readonly IMapper _mapper;

    public GetAnswerPollByIdQueryHandler(
        IRepository<AnswerPoll> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AnswerPollDto> Handle(
        GetAnswerPollByIdQuery request,
        CancellationToken ct)
    {
        var answerPoll = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<AnswerPollDto>(answerPoll);
    }
}