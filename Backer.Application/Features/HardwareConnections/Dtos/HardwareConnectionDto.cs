namespace Backer.Application.Features.HardwareConnections.Dtos;

public record HardwareConnectionDto
{
    public HardwareConnectionDto() { } // For AutoMapper

    public HardwareConnectionDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateHardwareConnectionDto(string Title);

public record UpdateHardwareConnectionDto(int Id, string Title);