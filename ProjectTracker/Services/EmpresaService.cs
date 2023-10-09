using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public Empresa GetEmpresaByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Empresa> GetListEmpresas()
        {
            try
            {
                var empresas = _empresaRepository.GetListEmpresas().Result;
                return empresas;
            } catch (Exception ex)
            {
                throw ex;
            }
             
        }
    }
}
