namespace DotNetBase.Entities.Dto.RequestModels
{
    public class LoginDto
    {
        public string EMail { get; set; }
        public string Password { get; set; }
        public bool RemindMe { get; set; }
    }
}
