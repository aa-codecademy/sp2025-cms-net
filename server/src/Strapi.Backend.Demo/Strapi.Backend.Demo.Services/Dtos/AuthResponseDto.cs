using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos;
public class AuthResponseDto
{
    [JsonPropertyName("jwt")]
    public string Jwt { get; set; }

    [JsonPropertyName("user")]
    public UserDto User { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }
}

public class UserDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }
}