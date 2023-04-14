using GerenciadorTarefas.Application.DTOs;
using GerenciadorTarefas.Application.Models;
using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Application.UseCases.Interface {
    public interface IUseCaseUsuario
    {
        Task CriarUsuarioAsync(UsuarioDto usuarioDto);
        Task<Usuario?> BuscarUsuarioAsync(string cadastroPessoaFisica);
        Task<Usuario> BuscarTarefasUsuarioAsync(string cadastroPessoaFisica);
        Task<Usuario?> AtualizarUsuarioAsync(UsuarioAtualizadoDTO usuarioAtualizadoDTO, Usuario usuario);

    }
}
