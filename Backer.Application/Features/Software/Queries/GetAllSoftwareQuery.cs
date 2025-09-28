using AutoMapper;
using Backer.Application.Features.HardwareRepairs.Dtos;
using Backer.Application.Features.Software.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using Backer.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.Software.Queries;

public record GetAllSoftwaresQuery : IRequest<IEnumerable<SoftwareDto>>;

public class GetAllSoftwaresQueryHandler
    : IRequestHandler<GetAllSoftwaresQuery, IEnumerable<SoftwareDto>>
{
    private readonly IRepository<Backer.Core.Entities.Software> _repository;
    private readonly IMapper _mapper;

    public GetAllSoftwaresQueryHandler(IRepository<Backer.Core.Entities.Software> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SoftwareDto>> Handle(
        GetAllSoftwaresQuery request,
        CancellationToken ct)
    {
        var items = await _repository.GetAllAsync();

        return items.Select(s => new SoftwareDto(
        s.Id,
        s.SoftwareName,
        DateConvertor.ToShamsiDate(s.CreateDate), 
        s.Description,
        s.IsActive));
    }
}