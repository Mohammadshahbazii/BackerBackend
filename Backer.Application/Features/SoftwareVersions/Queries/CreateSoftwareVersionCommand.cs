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

public record CreateSoftwareVersionCommand(CreateSoftwareVersionDto Dto) : IRequest<int>;

public class CreateSoftwareVersionCommandHandler : IRequestHandler<CreateSoftwareVersionCommand, int>
{
    private readonly IRepository<SoftwareVersion> _repository;

    public CreateSoftwareVersionCommandHandler(IRepository<SoftwareVersion> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateSoftwareVersionCommand request, CancellationToken ct)
    {
        var version = new SoftwareVersion
        {
            SoftwareId = request.Dto.SoftwareId,
            Version = request.Dto.Version,
            Link = request.Dto.Link,
            CreateDate = request.Dto.CreateDate ?? DateTime.UtcNow
        };

        await _repository.AddAsync(version);
        return version.Id;
    }
}

