using Strapi.Backend.Demo.Services.Dtos;

public interface IAuthService
{
    Task<AuthResponseDto> LoginAsync(AuthLoginRequestDto dto);
    Task<AuthResponseDto> RegisterAsync(AuthRegisterRequestDto dto);
}