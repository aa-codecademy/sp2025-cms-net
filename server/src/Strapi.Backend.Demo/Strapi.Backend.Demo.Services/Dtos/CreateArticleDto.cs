using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos;
public class CreateArticleDto
{
    [JsonPropertyName("articleId")]
    public int ArticleId { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("datePosted")]
    public DateTime DatePosted { get; set; } = DateTime.Now;
}

public class CreateArticleDataDto
{
    [JsonPropertyName("data")]
    public CreateArticleDto Article { get; set; }
}