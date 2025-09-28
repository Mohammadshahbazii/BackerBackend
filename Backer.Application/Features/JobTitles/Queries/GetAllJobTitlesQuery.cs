using AutoMapper;
using Backer.Application.Features.JobTitles.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.JobTitles.Queries;

public record GetAllJobTitlesQuery() : IRequest<List<JobTitleDto>>;

public class GetAllJobTitlesQueryHandler : IRequestHandler<GetAllJobTitlesQuery, List<JobTitleDto>>
{
    private readonly IRepository<JobTitle> _repository;
    private readonly IMapper _mapper;

    public GetAllJobTitlesQueryHandler(
        IRepository<JobTitle> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<JobTitleDto>> Handle(
        GetAllJobTitlesQuery request,
        CancellationToken cancellationToken)
    {
        var groups = await _repository.GetAllAsync();
        return _mapper.Map<List<JobTitleDto>>(groups);
    }
}
