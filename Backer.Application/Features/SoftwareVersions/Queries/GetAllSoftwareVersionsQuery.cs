using AutoMapper;
using AutoMapper.QueryableExtensions;
using Backer.Application.Features.Difficults.Dtos;
using Backer.Application.Features.Difficults.Queries;
using Backer.Application.Features.Software.Dtos;
using Backer.Application.Features.SoftwareVersions.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using Backer.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backer.Application.Features.SoftwareVersions.Queries;

public record GetAllSoftwareVersionsQuery : IRequest<IEnumerable<SoftwareVersionDto>>;

public class GetAllSoftwareVersionsQueryHandler : IRequestHandler<GetAllSoftwareVersionsQuery, IEnumerable<SoftwareVersionDto>>
{
    private readonly IRepository<SoftwareVersion> _repository;

    public GetAllSoftwareVersionsQueryHandler(IRepository<SoftwareVersion> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SoftwareVersionDto>> Handle(GetAllSoftwareVersionsQuery request, CancellationToken cancellationToken)
    {
        var versions = await _repository.Table
            .Include(d => d.Software)
            .ToListAsync();

        return versions.Select(v => new SoftwareVersionDto
        {
            Id = v.Id,
            SoftwareId = v.SoftwareId,
            Version = v.Version,
            Link = v.Link,
            CreateDate = DateConvertor.ToShamsiDate(v.CreateDate), // custom Persian conversion
            SoftwareName = v.Software?.SoftwareName
        });
    }
}
