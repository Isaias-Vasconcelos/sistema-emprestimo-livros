using GerenciamentoEmprestimoLivros.Application.Profiles;
using GerenciamentoEmprestimoLivros.Application.Services;
using GerenciamentoEmprestimoLivros.Application.Services.Implementations;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using GerenciamentoEmprestimoLivros.Infra.Database;
using GerenciamentoEmprestimoLivros.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciamentoEmprestimoLivros.Application.Module
{
    public static class ApplicationModule
    {
        public static IServiceCollection InjetarDependencias(this IServiceCollection services)
        {
            services
                .Repositories()
                .Services()
                .Profiles();

            return services;
        }

        static IServiceCollection Services(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILivroService, LivroService>();
            return services;
        }

        static IServiceCollection Repositories(this IServiceCollection services)
        {
            //Create tables
            Connection.CreateTables();

            // Add Repositories
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            return services;
        }

        static IServiceCollection Profiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationProfile));
            return services;
        }
    }
}
