using AutoMapper;
using Backer.Application.Features.Users.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;

namespace Backer.Application.Features.Users.Queries;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;

public class GetUserByIdQueryHandler
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(
        IRepository<User> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(
        GetUserByIdQuery request,
        CancellationToken ct)
    {
        var group = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<UserDto>(group);
    }
}