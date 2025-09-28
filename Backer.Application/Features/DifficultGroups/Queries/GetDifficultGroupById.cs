using AutoMapper;
using Backer.Application.Features.DifficultGroups.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.DifficultGroups.Queries;

public record GetDifficultGroupByIdQuery(int Id) : IRequest<DifficultGroupDto>;

public class GetDifficultGroupByIdQueryHandler
    : IRequestHandler<GetDifficultGroupByIdQuery, DifficultGroupDto>
{
    private readonly IRepository<DifficultGroup> _repository;
    private readonly IMapper _mapper;

    public GetDifficultGroupByIdQueryHandler(
        IRepository<DifficultGroup> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DifficultGroupDto> Handle(
        GetDifficultGroupByIdQuery request,
        CancellationToken ct)
    {
        var group = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<DifficultGroupDto>(group);
    }
}
