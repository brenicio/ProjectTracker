using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface ILogProcessoRepository
    {
        public void AddLogProcesso(ProcessoUsuario LogProcesso);
        public Task AddLogProcessoInicio(ProcessoUsuario LogProcesso);
        public Task AddLogProcessoPausa(ProcessoUsuario LogProcesso);
        public Task AddLogProcessoFim(ProcessoUsuario LogProcesso);
        public Task UpdateLogProcesso(LogProcesso LogProcesso);
        public Task<List<LogProcesso>> GetLogProcessoByUser(int idUser);
        public Task<LogProcesso> GetLastLogProcessoByIdProcesso(int idProcessoUsuario);
    }
}
