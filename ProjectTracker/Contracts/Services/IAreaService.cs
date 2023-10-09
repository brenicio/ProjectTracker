using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface IAreaService
    {
        public List<Area> GetListAreas();
        public Area GetAreaByID(int id);
    }
}
