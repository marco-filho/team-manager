using System;
using System.ComponentModel.DataAnnotations;

namespace TeamManager.ViewModels
{
    public class JogadorViewModel
    {
        [Key]
        [Required(ErrorMessage = "É necessário preencher o campo {0}.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o campo {0}.", AllowEmptyStrings = false)]
        [StringLength(20, ErrorMessage = "O campo {0} precisa conter no máximo {1} caracteres.")]
        public string NomeCompleto { get; set; }

        [Range(18, 100, ErrorMessage = "O campo {0} deve ser ao menos {1} e no máximo {2}.")]
        public int Idade { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser maior que zero.")]
        public int TimeId { get; set; }
    }
}
