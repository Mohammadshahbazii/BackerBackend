namespace Backer.Core.Entities;

public class PollSample : BaseEntity
{
    public string Name { get; set; }
    public int JobTitleId { get; set; }
    public JobTitle JobTitle { get; set; } // Navigation property
}