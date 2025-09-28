using Backer.Utilities;

namespace Backer.Application.Features.SoftwareVersions.Dtos;

public record SoftwareVersionDto
{
    public int Id { get; init; }
    public int SoftwareId { get; init; }
    public string Version { get; init; }
    public string? Link { get; init; }
    public DateTime? CreateDate { get; init; }
    public string? SoftwareName { get; init; } // If you want to include related data
}



public record CreateSoftwareVersionDto(
    int SoftwareId,
    string Version,
    string? Link,
    DateTime? CreateDate);

public record UpdateSoftwareVersionDto(
    int Id,
    int SoftwareId,
    string Version,
    string? Link,
    DateTime? CreateDate);