using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamManager.Domain.Entities
{
    public class Time : BaseModel
    {
        public string Nome { get; set; }
        public DateTime DataInclusao { get; set; }
        [ForeignKey("TimeId")]
        public IEnumerable<Jogador> Jogadores { get; set; }
    }
}