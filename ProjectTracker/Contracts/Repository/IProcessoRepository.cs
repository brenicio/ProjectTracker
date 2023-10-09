using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface IProcessoRepository
    {
        public Task<List<Processo>> GetListProcessos();
        public Processo GetProcessoByID(int id);
        public Task<List<Processo>> GetProcessoByIdArea(int idArea);
    }
}
