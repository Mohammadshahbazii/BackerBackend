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

public record GetTelephoneByIdQuery(int Id) : IRequest<TelephoneDto>;

public class GetTelephoneByIdQueryHandler
    : IRequestHandler<GetTelephoneByIdQuery, TelephoneDto>
{
    private readonly IRepository<Telephone> _repository;
    private readonly IMapper _mapper;

    public GetTelephoneByIdQueryHandler(
        IRepository<Telephone> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TelephoneDto> Handle(
        GetTelephoneByIdQuery request,
        CancellationToken ct)
    {
        var Telephone = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<TelephoneDto>(Telephone);
    }
}
