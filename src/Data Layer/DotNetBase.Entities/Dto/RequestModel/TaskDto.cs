namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateTask
    {
        public int? UserId { get; set; }
        public string TaskTitle { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsCompleted { get; set; }
        public int? ContactId { get; set; }
        public int? CompanyId { get; set; }
        public int? InteractionId { get; set; }
    }

    public class UpdateTask
    {
        public string TaskTitle { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
