using Strapi.Backend.Demo.Api.Dtos;
using Strapi.Backend.Demo.Api.Interfaces;

namespace Strapi.Backend.Demo.Api.Services;
public class ArticleService : IArticleService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ArticleService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _baseUrl = config["Strapi:BaseUrl"] ?? "http://localhost:1337/api";
    }

    public async Task<List<ArticleDto>> GetArticlesAsync()
    {
        var resp = await _httpClient.GetFromJsonAsync<ResponseDto<List<ArticleDto>>>($"{_baseUrl}/articles");
        return resp?.Data ?? [];
    }

    public async Task<ArticleDto?> GetArticleByIdAsync(int articleId)
    {
        var resp = await _httpClient.GetFromJsonAsync<ResponseDto<ArticleDto>>($"{_baseUrl}/articles/{articleId}");
        return resp?.Data;
    }
}
