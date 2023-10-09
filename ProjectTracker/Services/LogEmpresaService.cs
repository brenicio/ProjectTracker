using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Services
{
    public class LogEmpresaService : ILogEmpresaService
    {
        private readonly ILogEmpresaRepository _logEmpresaRepository;

        public LogEmpresaService(ILogEmpresaRepository logEmpresaRepository)
        {
            _logEmpresaRepository = logEmpresaRepository;
        }

        public void AddLogEmpresa(LogEmpresa LogEmpresa)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogEmpresaInicio(ProcessoUsuario processo)
        {
            await _logEmpresaRepository.AddLogEmpresaInicio(processo);
        }

        public async Task AddLogEmpresaPausa(ProcessoUsuario processo)
        {
            await _logEmpresaRepository.AddLogEmpresaPausa(processo);
        }

        public void UpdateLogEmpresa(LogEmpresa LogEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
