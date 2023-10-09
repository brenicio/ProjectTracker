using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Services
{
    public class LogProcessoService : ILogProcessoService
    {
        private readonly ILogProcessoRepository _logProcessoRepository;

        public LogProcessoService(ILogProcessoRepository logProcessoRepository)
        {
            _logProcessoRepository = logProcessoRepository;
        }

        public void AddLogProcesso(LogProcesso LogProcesso)
        {
            //this.UpdateLogProcesso(LogProcesso);
            //_logProcessoRepository.AddLogProcesso(LogProcesso);
            throw new NotImplementedException();
        }
        public List<LogProcesso> GetLogProcessoByUser(int idUser)
        {
            //var logProcessos = _logProcessoRepository.GetLogProcessoByUser(idUser).Result;
            //return logProcessos;

            throw new NotImplementedException();
        }

        public async Task AddLogProcessoInicio(ProcessoUsuario LogProcesso)
        {
           await _logProcessoRepository.AddLogProcessoInicio(LogProcesso);
        }

        public async Task AddLogProcessoPausa(ProcessoUsuario LogProcesso)
        {
            await _logProcessoRepository.AddLogProcessoPausa(LogProcesso);
        }
        public async Task AddLogProcessoFim(ProcessoUsuario LogProcesso)
        {
            await _logProcessoRepository.AddLogProcessoFim(LogProcesso);
        }

        public async Task UpdateLogProcesso(LogProcesso LogProcesso)
        {
            try
            {
                await _logProcessoRepository.UpdateLogProcesso(LogProcesso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LogProcesso> GetLastLogProcessoByIdProcesso(int idProcessoUsuario)
        {
            try
            {

               return await _logProcessoRepository.GetLastLogProcessoByIdProcesso(idProcessoUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
