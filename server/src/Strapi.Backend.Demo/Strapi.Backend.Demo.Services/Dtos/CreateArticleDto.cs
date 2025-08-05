using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos;
public class CreateArticleDto
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("content")]
    public List<ArticleParagraphNodeDto> Content { get; set; }
}

public class ArticleTextNodeDto
{
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class ArticleParagraphNodeDto
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("children")]
    public List<ArticleTextNodeDto> Children { get; set; }
}

//public class ArticleDto
//{
//    [JsonPropertyName("id")]
//    public int Id { get; set; }

//    [JsonPropertyName("title")]
//    public string Title { get; set; }

//    [JsonPropertyName("content")]
//    public List<ArticleParagraphNodeDto> Content { get; set; }

//    [JsonPropertyName("createdAt")]
//    public DateTime CreatedAt { get; set; }

//    [JsonPropertyName("updatedAt")]
//    public DateTime UpdatedAt { get; set; }

//    [JsonPropertyName("publishedAt")]
//    public DateTime PublishedAt { get; set; }
//}
