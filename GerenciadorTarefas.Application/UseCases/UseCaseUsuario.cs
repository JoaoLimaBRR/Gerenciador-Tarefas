using GerenciadorTarefas.Domain.Models;
using GerenciadorTarefas.Application.Dto;
using GerenciadorTarefas.Application.UseCases.Interface;
using GerenciadorTarefas.Domain.Gateways;
using GerenciadorTarefas.Application.Models;

namespace GerenciadorTarefas.Application.UseCases {
    public class UseCaseUsuario : IUseCaseUsuario
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UseCaseUsuario(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario?> BuscarUsuarioAsync(string cadastroPessoaFisica)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioAsync(cadastroPessoaFisica);
            return usuario;
        }

        public async Task<Usuario> BuscarTarefasUsuarioAsync(string cadastroPessoaFisica)
        {
            var usuario = await _usuarioRepository.BuscarTarefasUsuarioAsync(cadastroPessoaFisica);
            return usuario;
        }

        public async Task CriarUsuarioAsync(UsuarioDto usuarioDto) 
        {
            var usuario = PreencherUsuario(usuarioDto);

            await _usuarioRepository.CriarUsuarioAsync(usuario);
        }

        public async Task<Usuario?> AtualizarUsuarioAsync(UsuarioAtualizadoDTO usuarioAtualizadoDTO, Usuario usuario)
        {
            var usuarioAtualizado = PreencherUsuarioAtualizado(usuarioAtualizadoDTO, usuario);
            
            if (usuarioAtualizado !=  null)
                await _usuarioRepository.AtualizarUsuarioAsync(usuarioAtualizado);

            return usuarioAtualizado;
        }

        private Usuario? PreencherUsuarioAtualizado(UsuarioAtualizadoDTO usuarioAtualizadoDTO, Usuario usuario)
        {
            return new Usuario(
               usuarioAtualizadoDTO.Nome == null ? "" : usuarioAtualizadoDTO.Nome,
               usuarioAtualizadoDTO.DataNascimento,
               usuario.Cpf == null ? "" : usuario.Cpf
           );
        }

        private Usuario PreencherUsuario(UsuarioDto usuarioDto)
        {
            return new Usuario(
                usuarioDto.Nome == null ? "" : usuarioDto.Nome,
                usuarioDto.DataNascimento,
                usuarioDto.Cpf == null ? "" : usuarioDto.Cpf

            );
        }
    }

}
