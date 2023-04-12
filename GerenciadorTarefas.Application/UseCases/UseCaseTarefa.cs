using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Domain.Gateways;
using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Application.UseCases {
    public class UseCaseTarefa : IUseCaseTarefa
    {
        private readonly ITarefaRepository _tarefaReposiroty;
        public UseCaseTarefa(ITarefaRepository tarefaReposiroty)
        {
            _tarefaReposiroty = tarefaReposiroty;
        }
        public IEnumerable<Tarefa> BuscarTarefas()
        {
            return _tarefaReposiroty.BuscarTarefas();
        }
    }
}