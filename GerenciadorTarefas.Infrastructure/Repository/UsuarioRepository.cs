using System.Data.Common;
using GerenciadorTarefas.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GerenciadorTarefas.Domain.Gateways;
using Dapper;

namespace GerenciadorTarefas.Insfrastructre.Repository{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string? _connectionString;
        public UsuarioRepository(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");
        public async Task CriarUsuarioAsync(Usuario usuario)
        {
            var command = "INSERT USUARIO(NOME, DATANASCIMENTO, CPF) VALUES (@NOME, @DATANASCIMENTO, @CPF)";

            using(var dbConnection = new SqlConnection(_connectionString)){
                var parans = new {usuario.Nome, usuario.DataNascimento, usuario.Cpf};
                await dbConnection.ExecuteAsync(command, parans);
            }
        }

        public async Task<Usuario> BuscarUsuarioAsync(string cadastroPessoaFisica)
        {
            var commandSql = "SELECT * FROM USUARIO WHERE CPF = @CPF";

            using(var dbConnection = new SqlConnection(_connectionString))
                return await dbConnection.QueryFirstAsync<Usuario>( commandSql, new {CPF = cadastroPessoaFisica});

        }

        public async Task<Usuario> BuscarTarefasUsuarioAsync(string cadastroPessoaFisica)
        {
            var commandSql = "SELECT * FROM USUARIO INNER JOIN TAREFA ON USUARIO.Cpf = TAREFA.Cpf INNER JOIN SITUACAO ON SITUACAO.Codigo = TAREFA.CodigoSituacao WHERE USUARIO.Cpf = @CPF";
            var usuarioRetorno = new Usuario();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                await sqlConnection.QueryAsync<Usuario, Tarefa, Situacao, Usuario>(
                    commandSql,
                    (usuario, tarefa, situacao) =>
                    { 
                        if (usuarioRetorno.Cpf == null){
                            usuarioRetorno = usuario;
                            tarefa.Situacao = situacao;
                            usuarioRetorno.Tarefas.Add(tarefa);
                        } else{
                            tarefa.Situacao = situacao;
                            usuarioRetorno.Tarefas.Add(tarefa);
                        }
                        return usuario;
                    }, new {CPF = cadastroPessoaFisica}, splitOn: "IdTarefa,Codigo"
                );

                return usuarioRetorno;
            }
        }

        public async Task AtualizarUsuarioAsync(Usuario usuario)
        {
            var comandoSql = "UPDATE USUARIO SET NOME = @NOME, DATANASCIMENTO = @DATANASCIMENTO WHERE CPF = @CPF";
            using(var sqlConnection = new SqlConnection(_connectionString)){

                var teste = await sqlConnection.ExecuteReaderAsync(
                    comandoSql,
                    new {
                        NOME = usuario.Nome,
                        DATANASCIMENTO = usuario.DataNascimento,
                        CPF = usuario.Cpf
                    }
                );

            }

        }
    }
}