using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos;
public class AuthLoginRequestDto
{
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}