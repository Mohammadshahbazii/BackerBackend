using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backer.Application.Features.Difficults.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backer.Application.Features.Difficults.Queries;

public record GetAllDifficultsQuery : IRequest<List<DifficultDto>>;

public class GetAllDifficultsQueryHandler : IRequestHandler<GetAllDifficultsQuery, List<DifficultDto>>
{
    private readonly IRepository<Difficult> _repository;
    private readonly IMapper _mapper;

    public GetAllDifficultsQueryHandler(IRepository<Difficult> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<DifficultDto>> Handle(GetAllDifficultsQuery request, CancellationToken cancellationToken)
    {
        var difficults = await _repository.Table
            .Include(d => d.DifficultGroup)
            .ProjectTo<DifficultDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return difficults;
    }
}
