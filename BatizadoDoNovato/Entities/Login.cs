using System.ComponentModel.DataAnnotations;

namespace BatizadoDoNovato.Entities;
public class Login
{
    [MaxLength(10, ErrorMessage = "Você ultrapassou o limite de 10 letras.")]
    [RegularExpression("^[A-Z]*$", ErrorMessage = "Somente letras maiúsculas são permitidas.")]
    public string Usuario { get; set; }
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,15}$", 
        ErrorMessage = "A senha deve ter no mínimo 8 e no máximo 15 caracteres, incluindo pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string Senha { get; set; }
}