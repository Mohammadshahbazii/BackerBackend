namespace Backer.Application.Features.AccessGroups.Dtos;

public record AccessGroupDto
{
    public AccessGroupDto() { } // For AutoMapper

    public AccessGroupDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateAccessGroupDto(string Title);