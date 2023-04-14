using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Domain.Gateways {
    public interface ITarefaRepository{
        Task<IEnumerable<Tarefa>> BuscarTarefasAsync();

        Task CriarTarefaAsync(Tarefa tarefa);
    }
}