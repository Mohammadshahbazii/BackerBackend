using Backer.Application.Features.Software.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Software.Queries;

public record CreateSoftwareCommand(CreateSoftwareDto Dto) : IRequest<int>;

public class CreateSoftwareCommandHandler : IRequestHandler<CreateSoftwareCommand, int>
{
    private readonly IRepository<Backer.Core.Entities.Software> _repository;

    public CreateSoftwareCommandHandler(IRepository<Backer.Core.Entities.Software> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateSoftwareCommand request, CancellationToken ct)
    {
        var software = new Backer.Core.Entities.Software
        {
            Description = request.Dto.Description,
            IsActive = request.Dto.IsActive,
            SoftwareName = request.Dto.SoftwareName,
            CreateDate = request.Dto.CreateDate ?? DateTime.UtcNow
        };

        await _repository.AddAsync(software);
        return software.Id;
    }
}
