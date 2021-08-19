using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.WebUi.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } 
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Senha", ErrorMessage = "A senha não confere")]
        public string ConfirmePassword { get; set; }


    }
}
