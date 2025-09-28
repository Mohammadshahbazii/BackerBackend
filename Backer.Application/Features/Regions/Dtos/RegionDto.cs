namespace Backer.Application.Features.Regions.Dtos;

public record RegionDto
{
    public RegionDto() { } // For AutoMapper

    public RegionDto(int id, string title, int? parentId, string parentTitle = null)
    {
        Id = id;
        Title = title;
        ParentId = parentId;
        ParentTitle = parentTitle;
    }

    public int Id { get; init; }
    public string Title { get; init; }
    public int? ParentId { get; init; }     // Nullable
    public string ParentTitle { get; init; } // Optional for display
}

public record CreateRegionDto(string Title, int? ParentId);

public record UpdateRegionDto(int Id, string Title, int? ParentId);