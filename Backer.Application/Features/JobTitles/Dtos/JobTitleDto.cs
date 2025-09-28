namespace Backer.Application.Features.JobTitles.Dtos;

public record JobTitleDto
{
    public JobTitleDto() { } // For AutoMapper

    public JobTitleDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateJobTitleDto(string Title);

public record UpdateJobTitleDto(int Id , string Title);