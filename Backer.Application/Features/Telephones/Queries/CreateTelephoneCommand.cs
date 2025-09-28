using AutoMapper;
using Backer.Application.Features.Telephones.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Telephones.Queries;

public record CreateTelephoneCommand(CreateTelephoneDto Dto) : IRequest<int>;

public class CreateTelephoneCommandHandler : IRequestHandler<CreateTelephoneCommand, int>
{
    private readonly IRepository<Telephone> _repository;
    private readonly IMapper _mapper;

    public CreateTelephoneCommandHandler(IRepository<Telephone> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateTelephoneCommand request, CancellationToken cancellationToken)
    {
        var entity = new Telephone
        {
            TellNumber = request.Dto.TellNumber,
            Description = request.Dto.Description
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}