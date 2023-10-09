using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;
using System.Linq.Expressions;

namespace ProjectTracker.Services
{
    public class ProcessoService : IProcessoService
    {
        private readonly IProcessoRepository _processoRepository;
        public ProcessoService(IProcessoRepository processoRepository)
        {
            _processoRepository = processoRepository;
        }

        public List<Processo> GetListProcessos()
        {
            try
            {
                var processos = _processoRepository.GetListProcessos();
                return processos.Result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Processo GetProcessoByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Processo> GetProcessoByIdArea(int IdArea)
        {
            var processos = _processoRepository.GetProcessoByIdArea(IdArea);
            return processos.Result;
        }
    }
}
