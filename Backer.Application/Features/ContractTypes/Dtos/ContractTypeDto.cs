namespace Backer.Application.Features.ContractTypes.Dtos;

public record ContractTypeDto
{
    public ContractTypeDto() { } // For AutoMapper

    public ContractTypeDto(int id, string name, int? callCount)
    {
        Id = id;
        Name = name;
        CallCount = callCount;
    }

    public int Id { get; init; }
    public string Name { get; init; }
    public int? CallCount { get; init; } // Nullable
}

public record CreateContractTypeDto(string Name, int? CallCount);

public record UpdateContractTypeDto(int Id , string Name, int? CallCount);