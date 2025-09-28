namespace Backer.Application.Features.HardwareChanges.Dtos;

public record HardwareChangeDto
{
    public HardwareChangeDto() { } // For AutoMapper

    public HardwareChangeDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateHardwareChangeDto(string Title);

public record UpdateHardwareChangeDto(int Id, string Title);