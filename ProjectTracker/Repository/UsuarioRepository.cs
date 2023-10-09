using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Data;
using ProjectTracker.Models;

namespace ProjectTracker.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepository(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }

        public async Task<Usuario> GetUsuario(string usuario, string senha)
        {
            try
            {

                var usuarioLogado = await _bancoContext.Usuarios
                  .Where(l => l.Login.Equals(usuario))
                  .Where(s => s.Senha.Equals(senha))
                  .FirstOrDefaultAsync();

                return usuarioLogado;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _bancoContext.Usuarios.FirstAsync(x => x.Id == id);
                return usuario;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
