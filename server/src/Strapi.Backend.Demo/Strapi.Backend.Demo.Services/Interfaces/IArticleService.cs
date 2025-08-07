using Strapi.Backend.Demo.Services.Dtos;

namespace Strapi.Backend.Demo.Services.Interfaces;

public interface IArticleService
{
    Task<ResponseDto<List<ArticleDto>>> GetArticlesAsync();
    Task<ResponseDto<ArticleDto?>> GetArticleByIdAsync(string id);
    Task<ResponseDto<ArticleDto>> CreateArticleAsync(CreateArticleDataDto dto);
    Task<ResponseDto<ArticleDto>> UpdateArticleAsync(string articleId, UpdateArticleDto dto);
    Task<bool> DeleteArticleAsync(string articleId);
}
