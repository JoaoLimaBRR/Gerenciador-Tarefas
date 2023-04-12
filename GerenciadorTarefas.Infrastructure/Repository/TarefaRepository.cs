using Dapper;
using GerenciadorTarefas.Domain.Gateways;
using GerenciadorTarefas.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GerenciadorTarefas.Insfrastructre.Repository{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly string? _connectionString;

        public TarefaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Tarefa> BuscarTarefas()
        {
            var command = "SELECT * FROM TAREFA INNER JOIN SITUACAO ON TAREFA.CodigoSituacao = SITUACAO.Codigo";
            using(var connection = new SqlConnection(_connectionString)){

                return connection.Query<Tarefa, Situacao, Tarefa>(
                command,
                (tarefa, situacao) =>{
                    tarefa.Situacao = situacao;
                    return tarefa;
                }, splitOn: "Codigo");

            }
        }

         
    }
}