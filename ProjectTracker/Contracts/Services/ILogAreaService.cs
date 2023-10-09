using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface ILogAreaService
    {
        public void AddLogArea(LogArea area);
        public void UpdateLogArea(LogArea area);
        public Task AddLogAreaInicio(ProcessoUsuario processo);
        public Task AddLogAreaPausa(ProcessoUsuario processo);
        public void AddLogAreaEmpresa(ProcessoUsuario processo);
    }
}
