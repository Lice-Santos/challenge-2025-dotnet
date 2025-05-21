using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tria_2025.Models
{
    public class Moto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Placa é obrigatória")]
        [MaxLength(7, ErrorMessage = "A placa deve ter no máximo 7 caracteres.")]
        public string Placa { get; set; }
        [MaxLength(50, ErrorMessage = "O modelo da moto deve ter no máximo 50 caracteres.")]
        public string Modelo { get; set; }
        [StringLength(4, ErrorMessage = "O ano deve ter 4 caracteres")]
        [Range(1000, 9999, ErrorMessage = "O ano deve ter 4 dígitos.")]
        public int Ano { get; set; }
        [MaxLength(50, ErrorMessage = "O ti0ó de combustível deve ter no máximo 50 caracteres.")]
        public string TipoCombustivel { get; set; }
        [Required(ErrorMessage = "O id da filial é obrigatório")]
        public int IdFilial { get; set; }

    }
}
