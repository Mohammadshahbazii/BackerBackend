using AutoMapper;
using Backer.Application.Features.Difficults.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Difficults.Queries;

public record GetDifficultByIdQuery(int Id) : IRequest<DifficultDto>;

public class GetDifficultByIdQueryHandler
    : IRequestHandler<GetDifficultByIdQuery, DifficultDto>
{
    private readonly IRepository<Difficult> _repository;
    private readonly IMapper _mapper;

    public GetDifficultByIdQueryHandler(
        IRepository<Difficult> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DifficultDto> Handle(
        GetDifficultByIdQuery request,
        CancellationToken ct)
    {
        var difficult = await _repository.GetByIdWithIncludeAsync(
            request.Id,
            d => d.DifficultGroup); // Now this will work

        return _mapper.Map<DifficultDto>(difficult);
    }
}
