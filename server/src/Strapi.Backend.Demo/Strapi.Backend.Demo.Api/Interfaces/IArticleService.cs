using Strapi.Backend.Demo.Api.Dtos;

namespace Strapi.Backend.Demo.Api.Interfaces;

public interface IArticleService
{
    Task<List<ArticleDto>> GetArticlesAsync();
    Task<ArticleDto?> GetArticleByIdAsync(int id);
}
