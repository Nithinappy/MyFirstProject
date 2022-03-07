using System.ComponentModel.DataAnnotations;

namespace MyFirstProject.Models;
public class Category
{
    public int Id { get; set; }
    [Required]
    public string CategoryName { get; set; }
    [Range(1, 10)]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;


}