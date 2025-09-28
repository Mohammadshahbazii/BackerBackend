using AutoMapper;
using Backer.Application.Features.SoftwareVersions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.SoftwareVersions.Queries;

public record GetSoftwareVersionByIdQuery(int Id) : IRequest<SoftwareVersionDto>;

public class GetSoftwareVersionByIdQueryHandler
    : IRequestHandler<GetSoftwareVersionByIdQuery, SoftwareVersionDto>
{
    private readonly IRepository<SoftwareVersion> _repository;
    private readonly IMapper _mapper;

    public GetSoftwareVersionByIdQueryHandler(IRepository<SoftwareVersion> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SoftwareVersionDto> Handle(GetSoftwareVersionByIdQuery request, CancellationToken ct)
    {
        var version = await _repository.GetByIdWithIncludeAsync(
            request.Id,
            v => v.Software);

        return _mapper.Map<SoftwareVersionDto>(version);
    }
}