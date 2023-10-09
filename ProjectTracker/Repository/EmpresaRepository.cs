using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;

namespace ProjectTracker.Repository
{
    public class EmpresaRepository : IEmpresaRepository         
    {
        private readonly BancoContext _bancoContext;

        public EmpresaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Empresa GetEmpresaByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Empresa>> GetListEmpresas()
        {
            try
            {
                var empresas = _bancoContext.Empresas.OrderBy(o=> o.Cidade).Where(x=> x.AtvItv == 0).ToListAsync();
                return empresas;
            } catch (Exception ex)
            {
                throw ex;
            }
            

        }
    }
}
