using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface ILogEmpresaService
    {
        public void AddLogEmpresa(LogEmpresa LogEmpresa);
        public void UpdateLogEmpresa(LogEmpresa LogEmpresa);
        public Task AddLogEmpresaInicio(ProcessoUsuario processo);
        public Task AddLogEmpresaPausa(ProcessoUsuario processo);
    }
}
