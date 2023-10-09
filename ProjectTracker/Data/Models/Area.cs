using System.Text.Json.Serialization;

namespace ProjectTracker.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string? Nome { get; set; }           
        public virtual List<UsrArea> UsrAreas { get; set; }  = new List<UsrArea>();
        public virtual List<Processo> Processos { get; set; } = new List<Processo>();         
        public virtual List<LogArea> LogAreas { get; set; } = new List<LogArea>();
    }
}
