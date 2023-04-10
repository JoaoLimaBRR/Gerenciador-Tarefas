using GerenciadorTarefas.Domain.Models;

namespace GerenciadorTarefas.Domain.Gateways {
    public interface IUsuarioRepository
    {
        Task CriarUsuario(Usuario usuario);
        Task<Usuario> BuscarUsuario(string cadastroPessoaFisica);
        Task AtualizarUsuario(Usuario usuario);
    }
}

