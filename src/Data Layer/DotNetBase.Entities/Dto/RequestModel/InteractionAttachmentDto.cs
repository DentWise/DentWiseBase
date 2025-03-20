namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateInteractionAttachment
    {
        public int? CompanyInteractionId { get; set; }
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public int? FileSize { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? UserId { get; set; }
    }
}
