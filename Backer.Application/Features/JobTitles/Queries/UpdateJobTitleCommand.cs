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

public record UpdateJobTitleCommand(UpdateJobTitleDto Dto) : IRequest<bool>;

public class UpdateJobTitleCommandHandler : IRequestHandler<UpdateJobTitleCommand, bool>
{
    private readonly IRepository<JobTitle> _repository;

    public UpdateJobTitleCommandHandler(IRepository<JobTitle> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateJobTitleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Dto.Id);
        if (entity == null) return false;

        entity.Title = request.Dto.Title;

        await _repository.UpdateAsync(entity);
        return true;
    }
}
