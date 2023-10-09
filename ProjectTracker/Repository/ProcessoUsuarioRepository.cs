using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;

namespace ProjectTracker.Repository
{
    public class ProcessoUsuarioRepository : IProcessoUsuarioRepository
    {
        private readonly BancoContext _bancoContext;

        public ProcessoUsuarioRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProcessoUsuario AddProcessoUsuario(ProcessoUsuario processo)
        {
            _bancoContext.ProcessosUsuario.Entry(processo).State = EntityState.Added;
            _bancoContext.ProcessosUsuario.Add(processo);
            _bancoContext.SaveChanges();
            return processo;
        }

        public void DeleteProcessoUsuario(ProcessoUsuario ProcessoUsuario)
        {
            if(ProcessoUsuario != null)
            {
                _bancoContext.ProcessosUsuario.Remove(ProcessoUsuario);
                _bancoContext.SaveChanges();
            }
        }

        public async Task<List<ProcessoUsuario>> GetListProcessosUsuario(int IdUser)
        {
            try
            {
                var processos = await _bancoContext.ProcessosUsuario.Where(x => x.IdUsuario == IdUser).Where(d => d.AtvItv == 0).ToListAsync();
                return processos;
            } catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<List<ProcessoUsuario>> GetListProcessosUsuarioFinalizados(int IdUser)
        {
            try
            {
                var processos = await _bancoContext.ProcessosUsuario
                    .Where(x => x.IdUsuario == IdUser)
                    .Where(d => d.AtvItv == 1)
                    .Where(c => c.Status.Equals("FIM")).ToListAsync();


                //AGRUPO OS PROCESSOS DE MESMO USUARIO, EMPRESA E PROCESSO E LISTA
                //var processos = _bancoContext.ProcessosUsuario
                //     .Where(x => x.IdUsuario == IdUser)
                //     .Where(d => d.AtvItv == 1)
                //     .Where(c => c.Status.Equals("FIM"))
                //     .GroupBy(e => new {e.IdEmpresa, e.IdUsuario, e.IdProcesso})
                //     .Select(g => g.OrderByDescending(e => e.DataInicial).First())                     
                //     .ToListAsync();

                return processos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProcessoUsuario GetProcessoUsuario(int Id)
        {
            try
            {
                var processo = _bancoContext.ProcessosUsuario.Where(x => x.Id == Id).First();
                return processo;
            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public ProcessoUsuario GetProcessoUsuarioFinalizados(int id)
        {
            try
            {
                var processo = _bancoContext.ProcessosUsuario
                    .Where(x => x.Id == id)
                    .Where(d => d.Status.Equals("FIM"))
                    .Where(c => c.AtvItv == 1)
                    .First(); 
                return processo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProcessoUsuario(ProcessoUsuario ProcessoUsuario)
        {
            var processoaseratualizado = ProcessoUsuario;
            
            try
            {
                _bancoContext.ProcessosUsuario.Entry(ProcessoUsuario).State = EntityState.Modified;
                await _bancoContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
