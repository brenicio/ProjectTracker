using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Repository
{
    public interface IUsuarioRepository
    {
        public Task<Usuario> GetUsuario(string usuario, string senha);
        public Task<Usuario> GetUsuarioById(int id);
    }
}
