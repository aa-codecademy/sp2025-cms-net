using System.Net.Http.Json;
using System.Text.Json;
using Strapi.Backend.Demo.Services.Dtos;
using Strapi.Backend.Demo.Services.Interfaces;

namespace Strapi.Backend.Demo.Services.Services;
public class ArticleService : IArticleService
{
    private readonly HttpClient _httpClient;

    public ArticleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseDto<List<ArticleDto>>> GetArticlesAsync()
    {
        var request = await _httpClient.GetAsync("articles");
        var resp = await request.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ResponseDto<List<ArticleDto>>>(resp);
        return result;
    }

    public async Task<ResponseDto<ArticleDto?>> GetArticleByIdAsync(string articleId)
    {
        var request = await _httpClient.GetAsync($"articles/{articleId}");
        var resp = await request.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ResponseDto<ArticleDto>>(resp);
        return result;
    }

    public async Task<ResponseDto<ArticleDto>> CreateArticleAsync(CreateArticleDto dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

        var request = await _httpClient.PostAsync("articles", content);
        var resp = await request.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<ResponseDto<ArticleDto>>(resp);
        return result;
    }

    public async Task<ResponseDto<ArticleDto>> UpdateArticleAsync(string articleId, UpdateArticleDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"articles/{articleId}", dto);
        var resp = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ResponseDto<ArticleDto>>(resp);
        return result;
    }

    public async Task<bool> DeleteArticleAsync(string articleId)
    {
        var response = await _httpClient.DeleteAsync($"articles/{articleId}");
        return response.IsSuccessStatusCode;
    }
}
