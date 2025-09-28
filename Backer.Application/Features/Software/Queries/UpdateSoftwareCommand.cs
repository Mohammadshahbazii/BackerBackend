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

public record UpdateSoftwareCommand(UpdateSoftwareDto Dto) : IRequest<bool>;

public class UpdateSoftwareCommandHandler : IRequestHandler<UpdateSoftwareCommand, bool>
{
    private readonly IRepository<Backer.Core.Entities.Software> _repository;

    public UpdateSoftwareCommandHandler(IRepository<Backer.Core.Entities.Software> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateSoftwareCommand request, CancellationToken ct)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.IsActive = request.Dto.IsActive;
        entity.SoftwareName = request.Dto.SoftwareName;
        entity.CreateDate = request.Dto.CreateDate;
        entity.Description = request.Dto.Description;


        await _repository.UpdateAsync(entity);
        return true;
    }
}