using AutoMapper;
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

public record GetAllAskPollsQuery : IRequest<List<AskPollDto>>;

public class GetAllAskPollsQueryHandler : IRequestHandler<GetAllAskPollsQuery, List<AskPollDto>>
{
    private readonly IRepository<AskPoll> _repository;
    private readonly IMapper _mapper;

    public GetAllAskPollsQueryHandler(IRepository<AskPoll> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<AskPollDto>> Handle(GetAllAskPollsQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<AskPollDto>>(entities);
    }
}
