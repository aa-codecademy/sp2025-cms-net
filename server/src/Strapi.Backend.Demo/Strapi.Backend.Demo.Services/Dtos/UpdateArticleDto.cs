using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos;
public class UpdateArticleDto
{
    [JsonPropertyName("articleId")]
    public int ArticleId { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;    
    
    [JsonPropertyName("datePosted")]
    public DateTime DatePosted { get; set; }
}

public class UpdateArticleDataDto
{
    [JsonPropertyName("data")]
    public UpdateArticleDto Article { get; set; }
}