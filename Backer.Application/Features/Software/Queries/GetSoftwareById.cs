using AutoMapper;
using Backer.Application.Features.Software.Dtos;
using Backer.Core.Interfaces;
using MediatR;
using Backer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Software.Queries;

public record GetSoftwareByIdQuery(int Id) : IRequest<SoftwareDto>;

public class GetSoftwareByIdQueryHandler : IRequestHandler<GetSoftwareByIdQuery, SoftwareDto>
{
    private readonly IRepository<Backer.Core.Entities.Software> _repository;
    private readonly IMapper _mapper;

    public GetSoftwareByIdQueryHandler(IRepository<Backer.Core.Entities.Software> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SoftwareDto> Handle(GetSoftwareByIdQuery request, CancellationToken ct)
    {
        var software = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<SoftwareDto>(software);
    }
}
