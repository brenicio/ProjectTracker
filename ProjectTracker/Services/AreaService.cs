using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public Area GetAreaByID(int id)
        {
            throw new NotImplementedException();             
        }

        public List<Area> GetListAreas()
        {
            try
            {
                var areas = _areaRepository.GetListAreas();
                return areas.Result;
            }  catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
