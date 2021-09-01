namespace lemosinfotec.biblia.Domain.Entities
{
    public class Biblia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Versiculo { get; set; }
        public int Capitulo { get; set; }
        public string Conteudo { get; set; }
    }
}
