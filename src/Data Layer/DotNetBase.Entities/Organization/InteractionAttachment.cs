using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Organization
{
    public class InteractionAttachment : BaseEntity, ISoftDeletable
    {
        public int CompanyInteractionId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public int CreatorId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public CompanyInteraction CompanyInteraction { get; set; }
    }
}
