namespace Backer.Core.Entities;

public class ContractPackage : BaseEntity
{
    public string Title { get; set; }        // Required (Unchecked in DB)
    public string? Description { get; set; } // Nullable (Checked in DB)
}