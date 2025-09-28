using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.HardwareCartReaders.Queries;

public record DeleteHardwareCartReaderCommand(int Id) : IRequest<bool>;

public class DeleteHardwareCartReaderCommandHandler : IRequestHandler<DeleteHardwareCartReaderCommand, bool>
{
    private readonly IRepository<HardwareCartReader> _repository;

    public DeleteHardwareCartReaderCommandHandler(IRepository<HardwareCartReader> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteHardwareCartReaderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null)
            return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}
