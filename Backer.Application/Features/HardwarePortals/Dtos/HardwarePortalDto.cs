namespace Backer.Application.Features.HardwarePortals.Dtos;

public record HardwarePortalDto
{
    public HardwarePortalDto() { } // For AutoMapper

    public HardwarePortalDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateHardwarePortalDto(string Title);

public record UpdateHardwarePortalDto(int Id, string Title);