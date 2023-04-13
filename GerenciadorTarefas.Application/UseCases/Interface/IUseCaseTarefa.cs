
using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Application.UseCases.Interface {
    public interface IUseCaseTarefa
    {
        Task<IEnumerable<Tarefa>>  BuscarTarefasAsync();
    }
}