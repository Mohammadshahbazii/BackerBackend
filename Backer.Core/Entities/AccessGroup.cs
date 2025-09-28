namespace Backer.Core.Entities
{
    public class AccessGroup : BaseEntity
    {
        public string Title { get; set; }  // Required field

        public int? ParentId { get; set; }  // Nullable Parent ID for hierarchy

        public AccessGroup? ParentGroup { get; set; }
    }
}
