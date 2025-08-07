using System.Text.Json;
using System.Text;
using Strapi.Backend.Demo.Services.Dtos;

namespace Strapi.Backend.Demo.Services.Services;
public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AuthResponseDto> LoginAsync(AuthLoginRequestDto dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("auth/local", content);
        var resp = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AuthResponseDto>(resp);
    }

    public async Task<AuthResponseDto> RegisterAsync(AuthRegisterRequestDto dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("auth/local/register", content);
        var resp = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<AuthResponseDto>(resp);
    }
}