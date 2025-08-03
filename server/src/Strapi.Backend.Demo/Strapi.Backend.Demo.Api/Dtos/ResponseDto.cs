namespace Strapi.Backend.Demo.Api.Dtos
{
    public class ResponseDto<T>
    {
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
