using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface IAreaRepository
    {
        public Task<List<Area>> GetListAreas();
        public Area GetAreaByID(int id);
    }
}
