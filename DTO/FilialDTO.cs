using System.ComponentModel.DataAnnotations;

namespace Tria_2025.DTO
{
    public class FilialDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public int IdEndereco { get; set; }
    }

}
