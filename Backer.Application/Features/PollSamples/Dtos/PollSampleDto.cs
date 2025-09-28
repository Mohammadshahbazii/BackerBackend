namespace Backer.Application.Features.PollSamples.Dtos;

public record PollSampleDto
{
    public PollSampleDto() { } // For AutoMapper

    public PollSampleDto(int id, string name, int jobTitleId, string jobTitle)
    {
        Id = id;
        Name = name;
        JobTitleId = jobTitleId;
        JobTitleName = jobTitle;
    }

    public int Id { get; init; }
    public string Name { get; init; }
    public int JobTitleId { get; init; }
    public string JobTitleName { get; init; }
}

public record CreatePollSampleDto(string name, int jobTitleId);

public record UpdatePollSampleDto(int Id , string Name, int JobTitleId);