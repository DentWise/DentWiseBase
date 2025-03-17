using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Enum;

namespace DotNetBase.Entities.Identity
{
    public class VerificationCode : BaseEntity, ISoftDeletable 
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public VerificationCodeTypeEnum CodeType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool isUsed { get; set; } = false;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public User User { get; set; }
    }
}
