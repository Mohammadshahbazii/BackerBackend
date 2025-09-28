namespace Backer.Core.Entities;

public class SoftwareVersion : BaseEntity
{
    public int SoftwareId { get; set; }      // Required (Unchecked)
    public string Version { get; set; }      // Required (Unchecked) - Note: Fixed typo from "Vresion" to "Version"
    public string? Link { get; set; }        // Nullable (Checked)
    public DateTime? CreateDate { get; set; } // Nullable (Checked)

    public Software Software { get; set; }
}