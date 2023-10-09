namespace ProjectTracker.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public int Lotes { get; set; }
        public float AreaTotal { get; set; }
        public int AtvItv { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Observacao { get; set; }
        public virtual List<LogArea>? LogAreas { get; set; }
        public virtual List<LogEmpresa>? LogEmpresas { get; set; }
        public virtual List<ProcessoUsuario>? ProcessosUsuario { get; set; }
    }
}
                                                                                                                         