using Backer.Application.Features.HardwareCartReaders.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareCartReaders.Queries;

public record UpdateHardwareCartReaderCommand(UpdateHardwareCartReaderDto Dto) : IRequest<bool>;


public class UpdateHardwareCartReaderCommandHandler : IRequestHandler<UpdateHardwareCartReaderCommand, bool>
{
    private readonly IRepository<HardwareCartReader> _repository;

    public UpdateHardwareCartReaderCommandHandler(IRepository<HardwareCartReader> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateHardwareCartReaderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.id);
        if (entity == null) return false;

        entity.Title = request.Dto.title;
        await _repository.UpdateAsync(entity);

        return true;
    }
}
