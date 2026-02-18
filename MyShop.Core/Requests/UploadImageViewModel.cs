using System.ComponentModel.DataAnnotations;

namespace MyShop.Core.Requests;

public class UploadImageViewModel
{
    [Required(ErrorMessage = "Imagem inválida")]
    public string Base64Image { get; set; }
}