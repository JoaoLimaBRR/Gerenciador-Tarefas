using GerenciadorTarefas.Insfrastructre.DataProviders.Repositorys;
using GerenciadorTarefas.Domain.Gateways;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Application.UseCases;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GerenciadorTarefas.Insfrastructre.DataProviders.Interface;
using GerenciadorTarefas.Insfrastructre.DataProviders.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GerenciadorTarefas.Insfrastructre.Extensions{
    public static class ConfigureExtension
    {

        public static void ConfigureServices(this IServiceCollection services)
        {   
            services.AddTransient<IUseCaseUsuario, UseCaseUsuario>();
            services.AddTransient<IUseCaseTarefa, UseCaseTarefa>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<ITokenService, TokenService>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services, byte[] key){
            services.AddAuthentication( x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme =  JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}

