using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;

namespace ProjectTracker.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly BancoContext _bancoContext;

        public AreaRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public Area GetAreaByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Area>> GetListAreas()
        {
            return _bancoContext.Areas.OrderBy(o=> o.Nome).ToListAsync();
        }
    }
}
