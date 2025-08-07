using Strapi.Backend.Demo.Services.Dtos;
using Strapi.Backend.Demo.Services.Interfaces;

namespace Strapi.Backend.Demo.Api;

public static class ApiConfig
{
    public static void ConfigRoutes(WebApplication app)
    {
        app.MapGet("/api/articles", (IArticleService _articleService) =>
        {
            return _articleService.GetArticlesAsync();
        }).WithDescription("Get all articles")
          .WithDisplayName("GetAllArticles");

        app.MapGet("/api/articles/{articleId}", (string articleId, IArticleService _articleService) =>
        {
            return _articleService.GetArticleByIdAsync(articleId);

        }).WithDescription("Get single article by providing its Id value.")
          .WithDisplayName("GetArticleById");


        app.MapPost("/api/articles", async (CreateArticleDataDto dto, IArticleService service) =>
        {
            var result = await service.CreateArticleAsync(dto);
            return Results.Ok(result);
        });

        app.MapPut("/api/articles/{articleId}", async (string articleId, UpdateArticleDto dto, IArticleService service) =>
        {
            var result = await service.UpdateArticleAsync(articleId, dto);
            return Results.Ok(result);
        });

        app.MapDelete("/api/articles/{articleId}", async (string articleId, IArticleService service) =>
        {
            var success = await service.DeleteArticleAsync(articleId);
            return success ? Results.NoContent() : Results.NotFound();
        });
    }
}
