using Dapper;
using GerenciadorTarefas.Domain.Gateways;
using GerenciadorTarefas.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GerenciadorTarefas.Insfrastructre.Repository{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly string? _connectionString;

        public TarefaRepository(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection");

        public async Task<IEnumerable<Tarefa>> BuscarTarefasAsync()
        {
            var command = "SELECT * FROM TAREFA INNER JOIN SITUACAO ON TAREFA.CodigoSituacao = SITUACAO.Codigo";
            using(var connection = new SqlConnection(_connectionString)){

                return await connection.QueryAsync<Tarefa, Situacao, Tarefa>(
                command,
                (tarefa, situacao) =>{
                    tarefa.Situacao = situacao;
                    return tarefa;
                }, splitOn: "Codigo");

            }
        }

        public async Task CriarTarefaAsync(Tarefa tarefa)
        {
            var commandSql = "INSERT INTO TAREFA VALUES(@IDTAREFA, @CPFUSUARIOTAREFA, @TITULO, @DESCRICAO, @CODIGO)";

            using (var connection = new SqlConnection(_connectionString)){
                await connection.ExecuteAsync(
                    commandSql,
                    new {
                        tarefa.IdTarefa,
                        tarefa.CpfUsuarioTarefa,
                        tarefa.Titulo,
                        tarefa.Descricao,
                        tarefa.Situacao.Codigo
                    }   
                    
                );
            }

        }
    }
}