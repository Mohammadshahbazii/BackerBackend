using AutoMapper;
using Backer.Application.Features.Solutions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.Solutions.Queries.GetAllSolutions;

public class GetAllSolutionsQueryHandler
    : IRequestHandler<GetAllSolutionsQuery, IEnumerable<SolutionDto>>
{
    private readonly IRepository<Solution> _repository;
    private readonly IMapper _mapper;

    public GetAllSolutionsQueryHandler(
        IRepository<Solution> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SolutionDto>> Handle(
        GetAllSolutionsQuery request,
        CancellationToken cancellationToken)
    {
        var solutions = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<SolutionDto>>(solutions);
    }
}