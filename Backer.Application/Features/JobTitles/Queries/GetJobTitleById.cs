using AutoMapper;
using Backer.Application.Features.JobTitles.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.JobTitles.Queries;

public record GetJobTitleByIdQuery(int Id) : IRequest<JobTitleDto>;

public class GetJobTitleByIdQueryHandler
    : IRequestHandler<GetJobTitleByIdQuery, JobTitleDto>
{
    private readonly IRepository<JobTitle> _repository;
    private readonly IMapper _mapper;

    public GetJobTitleByIdQueryHandler(
        IRepository<JobTitle> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<JobTitleDto> Handle(
        GetJobTitleByIdQuery request,
        CancellationToken ct)
    {
        var jobTitle = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<JobTitleDto>(jobTitle);
    }
}