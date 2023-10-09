using Microsoft.EntityFrameworkCore;
using ProjectTracker.Data.Map;
using ProjectTracker.Models;

namespace ProjectTracker.Data
{
    public class BancoContext  :  DbContext      
    {
        public BancoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<LogProcesso> LogProcessos { get; set; }
        public DbSet<LogArea> LogAreas { get; set; }
        public DbSet<LogEmpresa> LogEmpresas { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<UsrArea> UsrAreas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProcessoUsuario> ProcessosUsuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new LogProcessoMap());
            modelBuilder.ApplyConfiguration(new LogAreaMap());
            modelBuilder.ApplyConfiguration(new LogEmpresaMap());
            modelBuilder.ApplyConfiguration(new ProcessoMap());
            modelBuilder.ApplyConfiguration(new UsrAreaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProcessoUsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
