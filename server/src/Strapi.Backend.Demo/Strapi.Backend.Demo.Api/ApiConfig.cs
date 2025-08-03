using Strapi.Backend.Demo.Api.Interfaces;
using Strapi.Backend.Demo.Api.Services;

namespace Strapi.Backend.Demo.Api;

public static class ApiConfig
{
    public static void ConfigRoutes(WebApplication app)
    {
        app.MapGet("/api/articles", (IArticleService _articleService) => _articleService.GetArticlesAsync());
        app.MapGet("/api/articles/{articleId:int}", (int articleId, IArticleService _articleService) => _articleService.GetArticleByIdAsync(articleId));
        // Add more endpoints here as needed
    }
}

