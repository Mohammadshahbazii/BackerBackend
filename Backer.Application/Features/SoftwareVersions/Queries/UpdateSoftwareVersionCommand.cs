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

public record UpdateSoftwareVersionCommand(UpdateSoftwareVersionDto Dto) : IRequest<bool>;

public class UpdateSoftwareVersionCommandHandler : IRequestHandler<UpdateSoftwareVersionCommand, bool>
{
    private readonly IRepository<SoftwareVersion> _repository;

    public UpdateSoftwareVersionCommandHandler(IRepository<SoftwareVersion> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateSoftwareVersionCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.SoftwareId = request.Dto.SoftwareId;
        entity.Version = request.Dto.Version;
        entity.CreateDate = request.Dto.CreateDate;
        entity.Link = request.Dto.Link;


        await _repository.UpdateAsync(entity);
        return true;
    }
}