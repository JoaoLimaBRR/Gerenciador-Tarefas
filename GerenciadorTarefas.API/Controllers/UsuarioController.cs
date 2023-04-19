using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Application.Models;
using GerenciadorTarefas.Domain.Models;
using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Insfrastructre.DataProviders.Interface;

namespace GerenciadorTarefas.API.Controllers{
    [ApiController]
    public class UsuarioController : ControllerBase {
        private readonly IUseCaseUsuario _useCaseUsuario;
        private readonly ITokenService _tokenService;
        public UsuarioController(IUseCaseUsuario useCaseUsuario, ITokenService tokenService){
           _useCaseUsuario = useCaseUsuario;
           _tokenService = tokenService;
        }  

        [HttpPost("v1/login")]
        public IActionResult Login(){
            var token = _tokenService.GeneratorToken(null);
            return Ok(token);
        }

        [HttpGet("v1/usuarios/{cadastroPessoaFisica}")]
        public async Task<IActionResult> BuscarUsuarioAsync([FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarUsuarioAsync(cadastroPessoaFisica);

            
            if (usuario == null)
            {
                return StatusCode(404, new ResultViewModel<Usuario?>("Usuario não encontrado"));
            }
            else
            {
                return Ok(new ResultViewModel<Usuario?>(usuario));    
            }
        }
        
        [HttpGet("v1/usuarios/tarefas/{cadastroPessoaFisica}")]
        public async Task<IActionResult> BuscarTarefasUsuario([FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarTarefasUsuarioAsync(cadastroPessoaFisica);
            if (usuario == null)
            {
                return StatusCode(404, new ResultViewModel<Usuario?>("Usuario não encontrado"));
            }
            else if(usuario.Tarefas == null){
                return StatusCode(404, new ResultViewModel<Usuario?>("Nenhuma tarefa cadastrada para este usuário"));
            }
            else
            {
                return Ok(usuario);
            }
        }

        [HttpPost("v1/usuarios")]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDto usuario)
        {
            await _useCaseUsuario.CriarUsuarioAsync(usuario);

            return Created($"v1/usuarios/{usuario.Cpf}",new ResultViewModel<UsuarioDto>(usuario));
        } 

        [HttpPut("v1/usuarios/{cadastroPessoaFisica}")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioAtualizadoDTO UsuarioAtualizadoDTO, [FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarUsuarioAsync(cadastroPessoaFisica);
             if (usuario == null) 
                return StatusCode(404, new ResultViewModel<Usuario?>("Usuario não encontrado"));
            
            var usuarioAtualizado = await _useCaseUsuario.AtualizarUsuarioAsync(UsuarioAtualizadoDTO, usuario);

            return Ok(new ResultViewModel<Usuario?>(usuarioAtualizado));
        }
    }
}