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
        public async Task<IActionResult> BuscarCliente([FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarUsuario(cadastroPessoaFisica);
            return Ok(new ResultViewModel<Usuario?>(usuario));
        }

        [HttpPost("v1/usuarios")]
        public async Task<IActionResult> CriarCliente([FromBody] UsuarioDto usuario)
        {
            await _useCaseUsuario.CriarUsuario(usuario);

            return Created($"v1/usuarios/{usuario.CadastroPessoaFisica}",new ResultViewModel<UsuarioDto>(usuario));
        } 

        [HttpPut("v1/usuarios/{cadastroPessoaFisica}")]
        public async Task<IActionResult> AtualizarCliente([FromBody] UsuarioAtualizadoDTO UsuarioAtualizadoDTO, [FromRoute] string cadastroPessoaFisica)
        {
            var usuario = await _useCaseUsuario.BuscarUsuario(cadastroPessoaFisica);
             if (usuario == null) 
                return StatusCode(404, "Usuário não encontrado");
            
            var usuarioAtualizado = await _useCaseUsuario.AtualizarUsuario(UsuarioAtualizadoDTO, usuario);

            return Ok(new ResultViewModel<Usuario?>(usuarioAtualizado));
        }
    }
}