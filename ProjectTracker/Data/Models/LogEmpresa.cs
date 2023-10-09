namespace ProjectTracker.Models
{
    public class LogEmpresa
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Status { get; set; } = String.Empty;
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public DateTime? DataCadastro { get; set; }
        public long? TempoDecorrido { get; set; }
        public virtual Empresa? Empresa { get; set; } = new Empresa();
    }
}
                                                