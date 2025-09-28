using AutoMapper;
using Backer.Application.Features.Solutions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore; 

namespace Backer.Application.Features.Solutions.Queries.GetSolutionsByTitle;

public class GetSolutionsByTitleQueryHandler
    : IRequestHandler<GetSolutionsByTitleQuery, IEnumerable<SolutionDto>>
{
    private readonly IRepository<Solution> _repository;
    private readonly IMapper _mapper;

    public GetSolutionsByTitleQueryHandler(
        IRepository<Solution> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SolutionDto>> Handle(
        GetSolutionsByTitleQuery request,
        CancellationToken cancellationToken)
    {
        var solutions = await _repository.FindAsync(
            s => EF.Functions.Like(s.Title, $"%{request.Title}%"));


        return _mapper.Map<IEnumerable<SolutionDto>>(solutions);
    }
}