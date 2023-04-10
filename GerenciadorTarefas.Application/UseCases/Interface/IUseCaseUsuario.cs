using GerenciadorTarefas.Application.Dto;
using GerenciadorTarefas.Application.Models;
using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Application.UseCases.Interface {
    public interface IUseCaseUsuario
    {
        Task CriarUsuario(UsuarioDto usuarioDto);
        Task<Usuario?> BuscarUsuario(string cadastroPessoaFisica);
        Task<Usuario?> AtualizarUsuario(UsuarioAtualizadoDTO usuarioAtualizadoDTO, Usuario usuario);

    }
}
