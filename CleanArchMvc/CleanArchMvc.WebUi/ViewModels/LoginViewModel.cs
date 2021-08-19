using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe um Email válido")]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe uma senha válida")]
        [StringLength(20, ErrorMessage = "The {A senha deve ter entre 6 e 20 caracteres", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
