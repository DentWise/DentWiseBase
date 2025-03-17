using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Organization;

namespace DotNetBase.Entities.Identity
{
    public class User : BaseEntity, ISoftDeletable
    {
        public string Username { get; set; }
        public required string EMail { get; set; }
        public required string HashedPassword { get; set; }
        public DateTime EmailVerifiedAt { get; set; }
        public bool IsEmailVerified { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime PhoneVerifiedAt { get; set; }
        public bool IsPhoneVerified { get; set; }
        public string? DiplomaNumber { get; set; }
        public string? ChamberREgistrationNumber { get; set; }
        public bool IsActive { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool TwoFactorSecret { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int RoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? ContactId { get; set; }

        // Navigation property
        public Role Role { get; set; } 
        public Company Company { get; set; }
        public Contact Contact { get; set; }
    }
}
