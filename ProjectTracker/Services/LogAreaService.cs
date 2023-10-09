using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Services
{
    public class LogAreaService : ILogAreaService
    {
        private readonly ILogAreaRepository _logAreaRepository;

        public LogAreaService(ILogAreaRepository logAreaRepository)
        {
            _logAreaRepository = logAreaRepository;
        }

        public void AddLogArea(ProcessoUsuario processo)
        {
            throw new NotImplementedException();
        }

        public void AddLogArea(LogArea area)
        {
            throw new NotImplementedException();
        }

        public void AddLogAreaEmpresa(ProcessoUsuario processo)
        {
            throw new NotImplementedException();
        }

        public async Task AddLogAreaInicio(ProcessoUsuario processo)
        {
            try
            {
                await _logAreaRepository.AddLogAreaInicio(processo);

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddLogAreaPausa(ProcessoUsuario processo)
        {
            try
            {
                await _logAreaRepository.AddLogAreaPausa(processo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateLogArea(ProcessoUsuario processo)
        {
            throw new NotImplementedException();
        }

        public void UpdateLogArea(LogArea area)
        {
            throw new NotImplementedException();
        }
    }
}
