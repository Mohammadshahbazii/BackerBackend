namespace Backer.Application.Features.HardwareCartReaders.Dtos;

public record HardwareCartReaderDto
{
    public HardwareCartReaderDto() { } // For AutoMapper

    public HardwareCartReaderDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateHardwareCartReaderDto(string Title);

public record UpdateHardwareCartReaderDto(int id, string title);