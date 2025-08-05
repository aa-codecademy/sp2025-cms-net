using System.ComponentModel.DataAnnotations;

namespace Strapi.Backend.Demo.Services.Dtos;
public class UpdateArticleDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}