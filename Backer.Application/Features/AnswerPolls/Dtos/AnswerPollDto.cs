namespace Backer.Application.Features.AnswerPolls.Dtos;

public record AnswerPollDto
{
    public AnswerPollDto() { } // For AutoMapper

    public AnswerPollDto(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public int Id { get; init; }
    public string Description { get; init; }
}

public record CreateAnswerPollDto(string Description);

public record UpdateAnswerPollDto(int Id , string Description);