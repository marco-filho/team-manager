using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace TeamManager.ViewModels
{
    public class TimeViewModel
    {
        [Key]
        [Required(ErrorMessage = "É necessário preencher o campo {0}.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o campo {0}.", AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O campo {0} precisa conter entre {1} e {2} caracteres.")]
        public string Nome { get; set; }

        [JsonIgnore]
        public DateTime DataInclusao { get; set; }

        [JsonPropertyName("dataInclusao")]
        public string DataInclusaoViewModel => DataInclusao.ToString("dd/MM/yyyy hh:mm");

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [ForeignKey("TimeId")]
        public IEnumerable<JogadorViewModel> Jogadores { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public float MediaDasIdades => GetMediaIdades(Jogadores);

        public float GetMediaIdades(IEnumerable<JogadorViewModel> jogadores)
        {
            if (jogadores == null) return 0;
            var idades = jogadores.Select(j => j.Idade);
            float sum = idades.Aggregate(0, (current, next) => current += next);
            return sum == 0 ? 0 : sum / jogadores.Count();
        }
    }
}
