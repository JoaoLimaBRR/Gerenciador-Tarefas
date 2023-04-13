using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Domain.Gateways {
    public interface IUsuarioRepository
    {
        Task CriarUsuarioAsync(Usuario usuario);
        Task<Usuario> BuscarUsuarioAsync(string cadastroPessoaFisica);
        Task<Usuario> BuscarTarefasUsuarioAsync(string cadastroPessoaFisica);
        Task AtualizarUsuarioAsync(Usuario usuario);
    }
}

