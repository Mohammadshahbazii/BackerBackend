namespace Backer.Application.Features.ContractPackages.Dtos;

public record ContractPackageDto
{
    public ContractPackageDto() { }

    public ContractPackageDto(int id, string title, string? description) // Note nullable
    {
        Id = id;
        Title = title;
        Description = description;
    }

    public int Id { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; } // Now nullable
}

public record CreateContractPackageDto(
    string Title,
    string? Description);

public record UpdateContractPackageDto(
    int Id,
    string Title,
    string? Description);