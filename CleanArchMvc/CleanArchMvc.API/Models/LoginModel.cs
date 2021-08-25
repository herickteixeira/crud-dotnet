using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe um Email válido")]
        [EmailAddress(ErrorMessage = "Informe um Email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe uma senha válida")]       
        [MinLength(6, ErrorMessage = "A senha deve conter no mínimo 6 digitos.")]
        [MaxLength(20, ErrorMessage = "A senha deve conter no máximo 20 digitos.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}
