namespace TeamManager.Domain.Entities
{
    public class Jogador : BaseModel
    {
        public string NomeCompleto { get; set; }
        public int Idade { get; set; }
        public int TimeId { get; set; }
    }
}