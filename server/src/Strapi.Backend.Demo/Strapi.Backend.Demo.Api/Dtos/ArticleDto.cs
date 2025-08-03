using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Api.Dtos;

public class ArticleDto
{
    [JsonPropertyName("articleId")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("datePosted")]
    public DateTime DatePosted { get; set; }

}

