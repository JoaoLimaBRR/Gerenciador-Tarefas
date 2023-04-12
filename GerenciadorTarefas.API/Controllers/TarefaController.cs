using GerenciadorTarefas.Application.Models;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.API.Controllers{
    [ApiController]
    public class TarefaController : ControllerBase {
        private readonly IUseCaseTarefa _useCaseTarefa;
        public TarefaController(IUseCaseTarefa useCaseTarefa) 
        {
            _useCaseTarefa = useCaseTarefa;
        }

        [HttpGet("v1/tarefas")]
        public async Task<IActionResult> BuscarTarefas()
        {
            var tarefa = _useCaseTarefa.BuscarTarefas();
            return Ok(tarefa);
        }

    }
}