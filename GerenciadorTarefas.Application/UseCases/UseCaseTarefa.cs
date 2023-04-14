using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Domain.Enums;
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

        public async Task<IEnumerable<Tarefa>> BuscarTarefasAsync()
        {
            return await _tarefaReposiroty.BuscarTarefasAsync();
        }

        public async Task CriarTarefaAsync(TarefaDTO tarefaDto)
        {
            var tarefa = MapearParaEntitade(tarefaDto);

            await _tarefaReposiroty.CriarTarefaAsync(tarefa);
        }

        private Tarefa MapearParaEntitade(TarefaDTO tarefaDTO){
            return 
                new Tarefa
                {
                    IdTarefa = new Guid(),
                    CpfUsuarioTarefa = tarefaDTO.CpfUsuario == null ? "" : tarefaDTO.CpfUsuario,
                    Titulo = tarefaDTO.Titulo,
                    Descricao = tarefaDTO.Descricao,
                    Situacao = new Situacao{
                        Codigo = ((int)ESituacao.ToDo)
                }

            };
        }
    }
}