// src/Backer.Application/Features/HardwareRepairs/Dtos/HardwareRepairDto.cs
namespace Backer.Application.Features.HardwareRepairs.Dtos;

public record HardwareRepairDto
{
    public HardwareRepairDto() { } // For AutoMapper

    public HardwareRepairDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; init; }
    public string Title { get; init; }
}

public record CreateHardwareRepairDto(string Title);

public record UpdateHardwareRepairDto(int Id, string Title);