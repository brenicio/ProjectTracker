using Microsoft.EntityFrameworkCore;
using ProjectTracker.Contracts.Repository;
using ProjectTracker.Contracts.Services;
using ProjectTracker.Data;
using ProjectTracker.Repository;
using ProjectTracker.Services;
using System.Text.Json.Serialization;

namespace ProjectTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthentication("Identity.Login")
                .AddCookie("Identity.Login", config =>
                {
                    config.Cookie.Name = "Identity.Login";
                    config.LoginPath = "/Login";
                    config.AccessDeniedPath = "/Login";
                    config.ExpireTimeSpan = TimeSpan.FromHours(1);
                });
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o =>
                {
                    o.UseSqlServer(builder.Configuration.GetConnectionString("Database"), builder => builder.EnableRetryOnFailure());
                    o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });

            builder.Services.AddScoped<IAreaService, AreaService>();
            builder.Services.AddScoped<IAreaRepository, AreaRepository>();

            builder.Services.AddScoped<IEmpresaService, EmpresaService>();
            builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            builder.Services.AddScoped<IProcessoService, ProcessoService>();
            builder.Services.AddScoped<IProcessoRepository, ProcessoRepository>();

            builder.Services.AddScoped<ILogProcessoService, LogProcessoService>();
            builder.Services.AddScoped<ILogProcessoRepository, LogProcessoRepository>();

            builder.Services.AddScoped<ILogAreaService, LogAreaService>();
            builder.Services.AddScoped<ILogAreaRepository, LogAreaRepository>();

            builder.Services.AddScoped<ILogEmpresaService, LogEmpresaService>();
            builder.Services.AddScoped<ILogEmpresaRepository, LogEmpresaRepository>();

            builder.Services.AddScoped<IProcessoUsuarioService, ProcessoUsuarioService>();
            builder.Services.AddScoped<IProcessoUsuarioRepository, ProcessoUsuarioRepository>();

            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod() // ou .WithMethods("PUT")
                           .AllowAnyOrigin(); // ajuste conforme sua necessidade
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseCors("MyCorsPolicy");

            app.UsePathBase("/Projetos");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}