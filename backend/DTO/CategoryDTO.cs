using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class CategoryDTO
{
    [Required]
    public string Name { get; set; } = string.Empty;

}