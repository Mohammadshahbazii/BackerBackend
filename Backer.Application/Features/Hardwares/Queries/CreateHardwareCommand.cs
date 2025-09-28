using AutoMapper;
using Backer.Application.Features.Hardwares.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Hardwares.Queries;

public record CreateHardwareCommand(CreateHardwareDto Dto) : IRequest<int>;

public class CreateHardwareCommandHandler : IRequestHandler<CreateHardwareCommand, int>
{
    private readonly IRepository<Hardware> _repository;
    private readonly IMapper _mapper;

    public CreateHardwareCommandHandler(IRepository<Hardware> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateHardwareCommand request, CancellationToken cancellationToken)
    {
        var entity = new Hardware
        {
            ModelName = request.Dto.ModelName,
            IsActive = request.Dto.IsActive
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
