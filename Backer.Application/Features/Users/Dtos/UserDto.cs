namespace Backer.Application.Features.Users.Dtos;

public record UserDto
{
    public int Id { get; init; }
    public string Username { get; init; }
    public string? Fullname { get; init; }
    public string? Tel { get; init; }
    public string? Email { get; init; }
    public DateTime BeginDate { get; init; }
    public DateTime? FinishDate { get; init; }

    // Foreign key relations
    public int JobId { get; init; }
    public string JobTitle { get; init; }

    public int? GroupId { get; init; }
    public string? GroupName { get; init; }

    public int? RegionId { get; init; }
    public string? RegionName { get; init; }
}

public record LoginRequestModel(string Username, string Password);

public record CreateUserDto(
    string Username,
    string Password,
    string? Fullname,
    string? Tel,
    string? Email,
    DateTime BeginDate,
    DateTime? FinishDate,
    int JobId,
    int? GroupId,
    int? RegionId);