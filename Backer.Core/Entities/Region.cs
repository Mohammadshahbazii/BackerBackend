namespace Backer.Core.Entities;

public class Region : BaseEntity
{
    public string Title { get; set; }       // Required (Unchecked in DB)
    public int? ParentId { get; set; }      // Nullable (Checked in DB)

    // Navigation properties
    public Region Parent { get; set; }      // Parent region
    public ICollection<Region> Children { get; set; } = new List<Region>(); // Child regions
}