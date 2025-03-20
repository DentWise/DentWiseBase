namespace DotNetBase.Entities.Dto.RequestModel
{
    public class CreateContactSentiment
    {
        public string? Name { get; set; }
        public int? Feeling { get; set; }
    }
    public class UpdateContactSentiment
    {
        public int? Feeling { get; set; }
    }
}
