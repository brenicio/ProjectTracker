using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface IProcessoUsuarioRepository
    {
        public Task<List<ProcessoUsuario>> GetListProcessosUsuario(int IdUsuario);
        public Task<List<ProcessoUsuario>> GetListProcessosUsuarioFinalizados(int IdUsuario);
        public ProcessoUsuario GetProcessoUsuario(int id);
        public ProcessoUsuario GetProcessoUsuarioFinalizados(int id);
        public ProcessoUsuario AddProcessoUsuario(ProcessoUsuario processo);
        public Task UpdateProcessoUsuario(ProcessoUsuario ProcessoUsuario);
        public void DeleteProcessoUsuario(ProcessoUsuario ProcessoUsuario);
    }
}
