using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.Application.Dto;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Application.Models;
using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.API.Controllers{
    [ApiController]
    public class UsuarioController : ControllerBase {
        private readonly IUseCaseUsuario _useCaseUsuario;
        public UsuarioController(IUseCaseUsuario useCaseUsuario) 
        {
            _useCaseUsuario = useCaseUsuario;
        }

        [HttpGet("v1/usuarios/{cadastroPessoaFisica}")]
        public async Task<IActionResult> BuscarUsuario([FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarUsuario(cadastroPessoaFisica);
            return Ok(new ResultViewModel<Usuario?>(usuario));
        }
        [HttpGet("v1/usuarios/tarefas/{cadastroPessoaFisica}")]
        public async Task<IActionResult> BuscarTarefasUsuario([FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarTarefasUsuarioAsync(cadastroPessoaFisica);
            return Ok(usuario);
        }

        [HttpPost("v1/usuarios")]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioDto usuario)
        {
            await _useCaseUsuario.CriarUsuario(usuario);

            return Created($"v1/usuarios/{usuario.Cpf}",new ResultViewModel<UsuarioDto>(usuario));
        } 

        [HttpPut("v1/usuarios/{cadastroPessoaFisica}")]
        public async Task<IActionResult> ArualizarUsuario([FromBody] UsuarioAtualizadoDTO UsuarioAtualizadoDTO, [FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarUsuario(cadastroPessoaFisica);
             if (usuario == null) 
                return StatusCode(404, new ResultViewModel<Usuario?>("Usuario não encontrado"));
            
            var usuarioAtualizado = await _useCaseUsuario.AtualizarUsuarioAsync(UsuarioAtualizadoDTO, usuario);

            return Ok(new ResultViewModel<Usuario?>(usuarioAtualizado));
        }
    }
}