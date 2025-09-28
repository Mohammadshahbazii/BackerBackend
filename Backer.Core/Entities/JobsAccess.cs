namespace Backer.Core.Entities
{
    public class JobsAccess : BaseEntity
    {
        public int AccessGroupID { get; set; } // Foreign Key to AccessGroup
        public AccessGroup AccessGroup { get; set; } // Navigation Property

        public int JobTitleID { get; set; } // Foreign Key to JobTitle
        public JobTitle JobTitle { get; set; } // Navigation Property
    }
}
