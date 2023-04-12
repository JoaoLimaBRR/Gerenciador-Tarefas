
using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Application.UseCases.Interface {
    public interface IUseCaseTarefa
    {
        IEnumerable<Tarefa>  BuscarTarefas();
    }
}