using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Requests.ProductRequest;

public class EditorProductRequest
{
    public int Id { get; set; }
    
    [Required(ErrorMessage =  "O Campo Nome é obrigatório")]
    [MaxLength(ErrorMessage = "Digite no máximo 50 caracteres")]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage =  "O Campo Nome é obrigatório")]
    [MaxLength(ErrorMessage = "Digite no máximo 50 caracteres")]
    public string Description { get; set; } = string.Empty;
    
    [DataType(DataType.Currency)]
    [Required(ErrorMessage =  "O Campo Nome é obrigatório")]
    public decimal Price { get; set; }
    
    public string ImageUrl { get; set; } = string.Empty;
    public int CategoryId { get; set; } 
}