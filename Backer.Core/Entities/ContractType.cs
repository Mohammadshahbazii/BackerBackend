namespace Backer.Core.Entities;

public class ContractType : BaseEntity
{
    public string Name { get; set; }      // Required (Unchecked in DB)
    public int? CallCount { get; set; }   // Nullable (Checked in DB)
}