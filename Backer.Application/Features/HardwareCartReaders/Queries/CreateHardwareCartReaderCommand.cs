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

public record CreateHardwareCartReaderCommand(CreateHardwareCartReaderDto Dto) : IRequest<int>;

public class CreateHardwareCartReaderCommandHandler : IRequestHandler<CreateHardwareCartReaderCommand, int>
{
    private readonly IRepository<HardwareCartReader> _repository;

    public CreateHardwareCartReaderCommandHandler(IRepository<HardwareCartReader> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(CreateHardwareCartReaderCommand request, CancellationToken cancellationToken)
    {
        var entity = new HardwareCartReader { Title = request.Dto.Title };
        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
