using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.Models
{
    public class ProcessoUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AtvItv { get; set; }
        public long? TempoDecorrido { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }         
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataMovimento { get; set; }
        public DateTime? DataInicioCronometro { get; set; }
        [Required]
        public string Status { get; set; } = String.Empty;
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdProcesso { get; set; }
        [Required]
        public int IdEmpresa { get; set; }
        public List<LogProcesso>? LogsProcessos { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual Empresa? Empresa { get; set; }
        public virtual Processo? Processo { get; set; }

    }
}
