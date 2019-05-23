namespace ProtechDDD.Dominio.Entities
{
    public class Experiencia
    {
        public int ExperienciaId { get; set; }
        public int PessoaId { get; set; }
        public string Tecnologia { get; set; }
        public int TempoExperiencia { get; set; }
        public string DetalheExperiencia { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
