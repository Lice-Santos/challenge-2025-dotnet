using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Tria_2025.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Logradouro é um campo obrigatório")]
        [MaxLength(250, ErrorMessage ="Logradouro deve ter no máximo 250 caracteres")]
        public string Logradouro { get; set; }
        [MaxLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres")]
        public string Cidade { get; set; }
        [MaxLength(50, ErrorMessage = "Estado deve ter no máximo 50 caracteres")]
        public string Estado { get; set; }
        [MaxLength(10, ErrorMessage = "Numero deve ter no máximo 10 caracteres")]
        public string Numero { get; set; }
        [MaxLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres")]
        public string Complemento { get; set; }
        //[Required(ErrorMessage = "CEP é um campo obrigatório")]
        //[MaxLength(9, ErrorMessage = "CEP deve ter no máximo 8 caracteres. Siga o padrão xxxxxxxx")]
        public string Cep { get; set; }

    }
}
