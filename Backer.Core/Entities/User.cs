namespace Backer.Core.Entities;

public class User : BaseEntity
{
    // Required fields (Unchecked)
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime BeginDate { get; set; }
    public int JobId { get; set; }

    // Optional fields (Checked)
    public string? Fullname { get; set; }
    public string? Tel { get; set; }
    public string? Address { get; set; }
    public string? Fax { get; set; }
    public string? Email { get; set; }
    public DateTime? FinishDate { get; set; }
    public int? GroupId { get; set; }
    public int? RegionId { get; set; }

    // Navigation properties
    public JobTitle JobTitle { get; set; }
    public AccessGroup Group { get; set; }
    public Region Region { get; set; }
}