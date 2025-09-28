using AutoMapper;
using Backer.Application.Features.HardwareConnections.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.HardwareConnections.Queries;

public record GetHardwareConnectionByIdQuery(int Id) : IRequest<HardwareConnectionDto>;

public class GetHardwareConnectionByIdQueryHandler
    : IRequestHandler<GetHardwareConnectionByIdQuery, HardwareConnectionDto>
{
    private readonly IRepository<HardwareConnection> _repository;
    private readonly IMapper _mapper;

    public GetHardwareConnectionByIdQueryHandler(
        IRepository<HardwareConnection> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwareConnectionDto> Handle(
        GetHardwareConnectionByIdQuery request,
        CancellationToken ct)
    {
        var connection = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwareConnectionDto>(connection);
    }
}