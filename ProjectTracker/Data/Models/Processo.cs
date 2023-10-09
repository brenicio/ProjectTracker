using System.Text.Json.Serialization;

namespace ProjectTracker.Models
{
    public class Processo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int IdArea { get; set; }
        public virtual Area Area { get; set; } = new Area();
        public virtual List<ProcessoUsuario> ProcessosUsuario { get; set; } = new List<ProcessoUsuario>();

    }
}
