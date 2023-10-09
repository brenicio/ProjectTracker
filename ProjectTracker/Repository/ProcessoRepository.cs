using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;
using System.Linq.Expressions;

namespace ProjectTracker.Repository
{
    public class ProcessoRepository : IProcessoRepository
    {
        private readonly BancoContext _bancoContext;

        public ProcessoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public Task<List<Processo>> GetListProcessos()
        {
            try
            {
                var processos = _bancoContext.Processos.OrderBy(o=> o.Nome).ToListAsync();
                return processos;
            }   catch(Exception ex)
            {
                throw ex;
            }
        }
        public Processo GetProcessoByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Processo>> GetProcessoByIdArea(int idArea)
        {
            try
            {
                var processos = _bancoContext.Processos.OrderBy(o => o.Nome).Where(c=> c.IdArea == idArea).ToListAsync();
                return processos;                 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
