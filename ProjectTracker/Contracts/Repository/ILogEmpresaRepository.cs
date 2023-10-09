using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface ILogEmpresaRepository
    {
        public void AddLogEmpresa(LogEmpresa LogEmpresa);
        public void UpdateLogEmpresa(LogEmpresa LogEmpresa);
        public Task AddLogEmpresaInicio(ProcessoUsuario processo);
        public Task AddLogEmpresaPausa(ProcessoUsuario processo);
    }
}
