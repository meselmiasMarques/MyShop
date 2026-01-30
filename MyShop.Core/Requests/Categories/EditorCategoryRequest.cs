using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Requests.Categories;

public class EditorCategoryRequest
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O Campo Nome é Obrigatório")]
    [MaxLength(50, ErrorMessage = "Você ultrapassou o limite de 50 Caracteres")]
    public string Title { get; set; }
}