using AutoMapper;
using Backer.Application.Features.JobTitles.Dtos;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.JobTitles.Queries;

public record CreateJobTitleCommand(CreateJobTitleDto Dto) : IRequest<int>;

public class CreateJobTitleCommandHandler : IRequestHandler<CreateJobTitleCommand, int>
{
    private readonly IRepository<JobTitle> _repository;
    private readonly IMapper _mapper;

    public CreateJobTitleCommandHandler(IRepository<JobTitle> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateJobTitleCommand request, CancellationToken cancellationToken)
    {
        var entity = new JobTitle
        {
            Title = request.Dto.Title,
        };

        await _repository.AddAsync(entity);
        return entity.Id;
    }
}
