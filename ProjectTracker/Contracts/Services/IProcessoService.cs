using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface IProcessoService
    {
        public List<Processo> GetListProcessos();
        public Processo GetProcessoByID(int id);
        public List<Processo> GetProcessoByIdArea(int IdArea);
    }
}
