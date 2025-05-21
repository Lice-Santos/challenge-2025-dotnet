using System.ComponentModel.DataAnnotations;

namespace Tria_2025.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Nome deve ter no máximo 250 caracteres.")]
        public string Nome { get; set; }
        [MaxLength(50, ErrorMessage = "Cargo deve ter no máximo 50 caracteres.")]
        public string Cargo { get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "Email deve ter no máximo 80 caracteres.")]
        public string Email { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Senha deve ter no máximo 30 caracteres.")]
        public string Senha { get; set; }

    }
}
