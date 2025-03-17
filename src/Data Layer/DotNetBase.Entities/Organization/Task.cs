using DotNetBase.Entities.Abstract;
using DotNetBase.Entities.Identity;
using System.Reflection.Metadata.Ecma335;

namespace DotNetBase.Entities.Organization
{
    public class Task : BaseEntity, ISoftDeletable
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public int CompanyId { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public User User { get; set; }
    }
}
