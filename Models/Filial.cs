using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace Tria_2025.Models
{
    public class Filial
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da filial é obrigatório")]
        [MaxLength(100, ErrorMessage = "A filial deve ter um nome de no máximo 100 caracteres.")]
        public string Nome { get; set; }
        [Required]
        public int IdEndereco { get; set; }
        [JsonIgnore]
        public Endereco Endereco { get; set; }
    }
}
