namespace ProjectTracker.Models.ViewModels
{
    public class ViewLogProcesso
    {
        public List<Empresa> Empresas { get; set; }
        public List<Area> Areas { get; set; }
        public List<Processo> Processos { get; set; }
        public List<LogProcesso> LogsProcessos { get; set; }
        public List<ProcessoUsuario> ProcessosUsuarios { get; set; }
        public List<ProcessoUsuario> ProcessosUsuariosHistorico { get; set; }
        public Usuario Usuario { get; set; }

        public ViewLogProcesso()
        {
            Empresas = new List<Empresa>();
            Areas = new List<Area>();
            Processos = new List<Processo>();
            LogsProcessos = new List<LogProcesso>();
            ProcessosUsuarios = new List<ProcessoUsuario>();
            ProcessosUsuariosHistorico = new List<ProcessoUsuario>();
            Usuario = new Usuario();
        }
    }
}
