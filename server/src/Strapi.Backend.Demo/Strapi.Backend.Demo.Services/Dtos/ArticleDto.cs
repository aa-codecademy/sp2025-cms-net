using System.Text.Json.Serialization;

namespace Strapi.Backend.Demo.Services.Dtos;

public class ArticleDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("articleId")]
    public int ArticleId { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("datePosted")]
    public DateTime DatePosted { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("publishedAt")]
    public DateTime PublishedAt { get; set; }

    [JsonPropertyName("documentId")]
    public string DocumentId { get; set; }
}

public class Pagination
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }

    [JsonPropertyName("pageCount")]
    public int PageCount { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public class Meta
{
    [JsonPropertyName("pagination")]
    public Pagination Pagination { get; set; }
}

