using Strapi.Backend.Demo.Services.Dtos;
using Strapi.Backend.Demo.Services.Interfaces;

namespace Strapi.Backend.Demo.Api;

public static class ApiConfig
{
    public static void ConfigRoutes(WebApplication app)
    {
        #region Article CRUD routes

        app.MapGet("/api/articles", (IArticleService _articleService) =>
        {
            return _articleService.GetArticlesAsync();
        })
        .Produces<ResponseDto<List<ArticleDto>>>(StatusCodes.Status200OK)
        .WithDescription("Get all articles")
        .WithDisplayName("GetAllArticles");


        app.MapGet("/api/articles/{articleId}", (string articleId, IArticleService _articleService) =>
        {
            return _articleService.GetArticleByIdAsync(articleId);
        })
        .Produces<ResponseDto<ArticleDto>>(StatusCodes.Status200OK)
        .WithDescription("Get single article by providing its Id value.")
        .WithDisplayName("GetArticleById");


        app.MapPost("/api/articles", async (CreateArticleDataDto dto, IArticleService service) =>
        {
            var result = await service.CreateArticleAsync(dto);
            return Results.Ok(result);
        })
        .Accepts<CreateArticleDataDto>("application/json")
        .Produces<ResponseDto<ArticleDto>>(StatusCodes.Status200OK)
        .WithDescription("Create a new article.")
        .WithDisplayName("CreateArticle");


        app.MapPut("/api/articles/{articleId}", async (string articleId, UpdateArticleDto dto, IArticleService service) =>
        {
            var result = await service.UpdateArticleAsync(articleId, dto);
            return Results.Ok(result);
        })
        .Accepts<UpdateArticleDto>("application/json")
        .Produces<ResponseDto<ArticleDto>>(StatusCodes.Status200OK)
        .WithDescription("Update an existing article by its Id.")
        .WithDisplayName("UpdateArticle");


        app.MapDelete("/api/articles/{articleId}", async (string articleId, IArticleService service) =>
        {
            var success = await service.DeleteArticleAsync(articleId);
            return success ? Results.NoContent() : Results.NotFound();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithDescription("Delete an article by its Id.")
        .WithDisplayName("DeleteArticle");

        #endregion

        #region Auth routes

        app.MapPost("/api/auth/login", async (AuthLoginRequestDto dto, IAuthService service) =>
        {
            var result = await service.LoginAsync(dto);
            return Results.Ok(result);
        })
        .Accepts<AuthLoginRequestDto>("application/json")
        .Produces<AuthResponseDto>(StatusCodes.Status200OK)
        .WithDescription("Authenticates a user and returns a JWT token.")
        .WithDisplayName("Login");


        app.MapPost("/api/auth/register", async (AuthRegisterRequestDto dto, IAuthService service) =>
        {
            var result = await service.RegisterAsync(dto);
            return Results.Ok(result);
        })
        .Accepts<AuthRegisterRequestDto>("application/json")
        .Produces<AuthResponseDto>(StatusCodes.Status200OK)
        .WithDescription("Registers a new user and returns a JWT token.")
        .WithDisplayName("Register");

        #endregion
    }
}
