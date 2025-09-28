namespace Backer.Core.Entities;

public class SolutionAssignToDifficult : BaseEntity
{
    public int DifficultId { get; set; }
    public Difficult Difficult { get; set; } // Navigation property

    public int SolutionId { get; set; }
    public Solution Solution { get; set; } // Navigation property
}