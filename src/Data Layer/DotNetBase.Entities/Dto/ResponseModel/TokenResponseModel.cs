namespace DotNetBase.Entities.Dto.ResponseModel
{
    public class TokenResponseModel
    {
        public required string Token { get; set; }
        public required string RefreshToken { get; set; }
    }

    public class BaseResponseModel<T>
    {
        public required bool Success { get; set; }
        public required string Message { get; set; }
        public T Data { get; set; }
    }
}
