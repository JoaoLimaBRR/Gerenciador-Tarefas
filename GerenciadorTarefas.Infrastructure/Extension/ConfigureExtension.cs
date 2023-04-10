using GerenciadorTarefas.Insfrastructre.Repository;
using GerenciadorTarefas.Domain.Gateways;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Application.UseCases;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorTarefas.Insfrastructre.Extension{
    public static class ConfigureExtension
    {
    
        public static void ConfigureServices(this IServiceCollection services)
        {   
            services.AddTransient<IUseCaseUsuario, UseCaseUsuario>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
    }
}

