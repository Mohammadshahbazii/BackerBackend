namespace Backer.Application.Features.DeviceContractSamples.Dtos;

public record DeviceContractSampleDto
{
    public DeviceContractSampleDto() { } // For AutoMapper

    public DeviceContractSampleDto(int id, string title, int? priority)
    {
        Id = id;
        Title = title;
        Priority = priority;
    }

    public int Id { get; init; }
    public string Title { get; init; }
    public int? Priority { get; init; } // Nullable
}

public record CreateDeviceContractSampleDto(string Title, int? Priority);