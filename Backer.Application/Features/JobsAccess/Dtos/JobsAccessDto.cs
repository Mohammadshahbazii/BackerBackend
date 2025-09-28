namespace Backer.Application.Features.JobsAccess.Dtos;

public record JobsAccessDto(
    int Id,
    int AccessGroupID,
    int JobTitleID);

public record CreateJobsAccessDto(
    int AccessGroupID,
    int JobTitleID);
