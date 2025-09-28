using System.Threading;
using System.Threading.Tasks;
using Backer.Core.Entities;
using Backer.Core.Interfaces;
using AutoMapper;
using MediatR;
using Backer.Application.Features.JobsAccess.Dtos;

namespace Backer.Application.Features.JobsAccess.Queries
{
    public record GetJobsAccessByIdQuery(int Id) : IRequest<JobsAccessDto>;
    public class GetJobsAccessByIdQueryHandler
        : IRequestHandler<GetJobsAccessByIdQuery, JobsAccessDto>
    {
        private readonly IRepository<Backer.Core.Entities.JobsAccess> _repository;
        private readonly IMapper _mapper;

        public GetJobsAccessByIdQueryHandler(IRepository<Backer.Core.Entities.JobsAccess> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<JobsAccessDto> Handle(GetJobsAccessByIdQuery request, CancellationToken ct)
        {
            var jobsAccess = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<JobsAccessDto>(jobsAccess);
        }
    }
}
