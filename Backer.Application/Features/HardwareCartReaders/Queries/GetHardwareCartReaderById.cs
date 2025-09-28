using AutoMapper;
using Backer.Application.Features.HardwareCartReaders.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.HardwareCartReaders.Queries;

public record GetHardwareCartReaderByIdQuery(int Id) : IRequest<HardwareCartReaderDto>;

public class GetHardwareCartReaderByIdQueryHandler
    : IRequestHandler<GetHardwareCartReaderByIdQuery, HardwareCartReaderDto>
{
    private readonly IRepository<HardwareCartReader> _repository;
    private readonly IMapper _mapper;

    public GetHardwareCartReaderByIdQueryHandler(
        IRepository<HardwareCartReader> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<HardwareCartReaderDto> Handle(
        GetHardwareCartReaderByIdQuery request,
        CancellationToken ct)
    {
        var reader = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<HardwareCartReaderDto>(reader);
    }
}