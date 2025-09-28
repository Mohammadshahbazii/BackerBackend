using AutoMapper;
using Backer.Application.Features.Solutions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.Solutions.Queries.GetSolutionById;

public class GetSolutionByIdQueryHandler : IRequestHandler<GetSolutionByIdQuery, SolutionDto>
{
    private readonly IRepository<Solution> _repository;
    private readonly IMapper _mapper;

    public GetSolutionByIdQueryHandler(
        IRepository<Solution> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SolutionDto> Handle(
        GetSolutionByIdQuery request,
        CancellationToken cancellationToken)
    {
        var solution = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<SolutionDto>(solution);
    }
}