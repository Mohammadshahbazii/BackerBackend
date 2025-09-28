namespace Backer.Application.Features.HardwareReplaces.Dtos;

public record HardwareReplaceDto(int Id, string Title);

public record CreateHardwareReplaceDto(string Title);

public record UpdateHardwareReplaceDto(int Id, string Title);