namespace Backer.Core.Entities;

public class DeviceContractSamplePrice : BaseEntity
{
    public int DeviceContractSampleId { get; set; }
    public DeviceContractSample DeviceContractSample { get; set; }
    public int Price { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
}