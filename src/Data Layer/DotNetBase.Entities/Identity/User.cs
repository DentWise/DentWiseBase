using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Identity
{
    public class User : BaseEntity, ISoftDeletable
    {
        public required string EMail { get; set; }
        public required string HashedPassword { get; set; }
        public bool IsMailConfirmed { get; set; }
        
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int RoleId { get; set; }

        // Navigation property
        public Role Role { get; set; } 
    }
}
