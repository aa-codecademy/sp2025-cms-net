using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos
{
    public class ResponseDto<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        public string ErrorMessage { get; set; }
    }
}
