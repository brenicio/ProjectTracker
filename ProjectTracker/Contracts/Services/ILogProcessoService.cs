using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface ILogProcessoService
    {
        public void AddLogProcesso(LogProcesso LogProcesso);
        public Task AddLogProcessoInicio(ProcessoUsuario LogProcesso);
        public Task AddLogProcessoPausa(ProcessoUsuario LogProcesso);
        public Task AddLogProcessoFim(ProcessoUsuario LogProcesso);
        public Task UpdateLogProcesso(LogProcesso LogProcesso);
        public List<LogProcesso> GetLogProcessoByUser(int idUser);
        public Task<LogProcesso> GetLastLogProcessoByIdProcesso(int idProcessoUsuario);
    }
}
