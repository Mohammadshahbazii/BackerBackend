using AutoMapper;
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

public record GetAllAnswerPollsQuery : IRequest<List<AnswerPollDto>>;

public class GetAllAnswerPollsQueryHandler : IRequestHandler<GetAllAnswerPollsQuery, List<AnswerPollDto>>
{
    private readonly IRepository<AnswerPoll> _repository;
    private readonly IMapper _mapper;

    public GetAllAnswerPollsQueryHandler(IRepository<AnswerPoll> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<AnswerPollDto>> Handle(GetAllAnswerPollsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<AnswerPollDto>>(entities);
    }
}
