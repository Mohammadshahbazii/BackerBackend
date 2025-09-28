namespace Backer.Core.Entities;

public class DeviceContractSample : BaseEntity
{
    public string Title { get; set; }     // Required (Unchecked in DB)
    public int? Priority { get; set; }    // Nullable (Checked in DB)
}