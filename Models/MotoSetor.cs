using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tria_2025.Models
{
    public class MotoSetor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data {  get; set; }
        [Required]
        [MaxLength(50, ErrorMessage ="O nome da fonte de informação deve ter no máximo 50 caracteres.")]
        public string Fonte { get; set; }
        [Required]

        public int IdMoto { get; set; }
        [Required]
        public int IdSetor { get; set; }

    }
}
