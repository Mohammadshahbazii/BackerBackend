namespace Backer.Application.Features.AskPolls.Dtos;

public record AskPollDto
{
    public AskPollDto() { } // For AutoMapper

    public AskPollDto(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public int Id { get; init; }
    public string Description { get; init; }
}

public record CreateAskPollDto(string Description);

public record UpdateAskPollDto(int Id , string Description);