using Backer.Core.Entities;
using Backer.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backer.Application.Features.JobTitles.Queries;

public record DeleteJobTitleCommand(int Id) : IRequest<bool>;

public class DeleteJobTitleCommandHandler : IRequestHandler<DeleteJobTitleCommand, bool>
{
    private readonly IRepository<JobTitle> _repository;

    public DeleteJobTitleCommandHandler(IRepository<JobTitle> repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteJobTitleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        if (entity == null) return false;

        await _repository.DeleteAsync(entity);
        return true;
    }
}