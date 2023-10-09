using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Models;

namespace ProjectTracker.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> GetUsuario(string usuario, string senha)
        {
            return await _usuarioRepository.GetUsuario(usuario, senha);
        }

        public Task<Usuario> GetUsuarioById(int id)
        {
            return _usuarioRepository.GetUsuarioById(id);
        }
    }
}
