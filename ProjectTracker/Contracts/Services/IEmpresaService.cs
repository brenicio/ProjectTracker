using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface IEmpresaService
    {
        public List<Empresa> GetListEmpresas();
        public Empresa GetEmpresaByID(int id);
    }
}
