namespace Backer.Application.Features.DeviceContractSamplePrices.Dtos;

public record DeviceContractSamplePriceDto
{
    public DeviceContractSamplePriceDto() { }

    public DeviceContractSamplePriceDto(
        int id,
        int deviceContractSampleId,
        string deviceContractSampleTitle,
        int price,
        DateTime beginDate,
        DateTime endDate)
    {
        Id = id;
        DeviceContractSampleId = deviceContractSampleId;
        DeviceContractSampleTitle = deviceContractSampleTitle;
        Price = price;
        BeginDate = beginDate;
        EndDate = endDate;
    }

    public int Id { get; init; }
    public int DeviceContractSampleId { get; init; }
    public string DeviceContractSampleTitle { get; init; }
    public int Price { get; init; }
    public DateTime BeginDate { get; init; }
    public DateTime EndDate { get; init; }
}

public record CreateDeviceContractSamplePriceDto(
    int DeviceContractSampleId,
    int Price,
    DateTime BeginDate,
    DateTime EndDate);