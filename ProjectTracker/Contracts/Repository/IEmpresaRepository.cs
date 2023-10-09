using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface IEmpresaRepository
    {
       public Task<List<Empresa>> GetListEmpresas();
       public Empresa GetEmpresaByID(int id);

    }
}
