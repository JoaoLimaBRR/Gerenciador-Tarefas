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

        public async Task<Usuario?> BuscarUsuario(string cadastroPessoaFisica)
        {
            var usuario = await _usuarioRepository.BuscarUsuario(cadastroPessoaFisica);
            return usuario;
        }

        public async Task CriarUsuario(UsuarioDto usuarioDto) 
        {
            var usuario = PreencherUsuario(usuarioDto);

            await _usuarioRepository.CriarUsuario(usuario);
        }

        public async Task<Usuario?> AtualizarUsuario(UsuarioAtualizadoDTO usuarioAtualizadoDTO, Usuario usuario)
        {
            var usuarioAtualizado = PreencherUsuarioAtualizado(usuarioAtualizadoDTO, usuario);
            
            await _usuarioRepository.AtualizarUsuario(usuarioAtualizado);

            return usuarioAtualizado;
        }

        private Usuario? PreencherUsuarioAtualizado(UsuarioAtualizadoDTO usuarioAtualizadoDTO, Usuario usuario)
        {
            return new Usuario(
               usuarioAtualizadoDTO.Nome == null ? "" : usuarioAtualizadoDTO.Nome,
               usuarioAtualizadoDTO.DataNascimento,
               usuario.CadastroPessoaFisica == null ? "" : usuario.CadastroPessoaFisica
           );
        }

        private Usuario PreencherUsuario(UsuarioDto usuarioDto)
        {
            return new Usuario(
                usuarioDto.Nome == null ? "" : usuarioDto.Nome,
                usuarioDto.DataNascimento,
                usuarioDto.CadastroPessoaFisica == null ? "" : usuarioDto.CadastroPessoaFisica

            );
        }
    }

}
