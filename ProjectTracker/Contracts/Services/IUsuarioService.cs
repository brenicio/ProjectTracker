using ProjectTracker.Models;

namespace ProjectTracker.Contracts.Services
{
    public interface IUsuarioService
    {
        public Task<Usuario> GetUsuario(string usuario, string senha);
        public Task<Usuario> GetUsuarioById(int id);
    }
}
