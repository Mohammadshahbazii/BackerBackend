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

public record GetAllTelephonesQuery : IRequest<List<TelephoneDto>>;

public class GetAllTelephonesQueryHandler : IRequestHandler<GetAllTelephonesQuery, List<TelephoneDto>>
{
    private readonly IRepository<Telephone> _repository;
    private readonly IMapper _mapper;

    public GetAllTelephonesQueryHandler(IRepository<Telephone> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TelephoneDto>> Handle(GetAllTelephonesQuery request, CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<List<TelephoneDto>>(entities);
    }
}