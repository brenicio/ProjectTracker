using MessagePack;

namespace ProjectTracker.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = String.Empty;
        public string Login { get; set; } = String.Empty;
        public string Senha { get; set; } = String.Empty;
        public string? Tipo { get; set; }
        public virtual List<UsrArea> UsrAreas { get; set; }  = new List<UsrArea>();
        public virtual List<ProcessoUsuario> ProcessosUsuario { get; set; } = new List<ProcessoUsuario>();
    }                                               
}
                                                                    