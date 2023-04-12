using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Domain.Gateways {
    public interface ITarefaRepository{
        IEnumerable<Tarefa> BuscarTarefas();
    }
}