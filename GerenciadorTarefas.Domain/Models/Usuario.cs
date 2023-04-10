namespace GerenciadorTarefas.Domain.Models {
    public class Usuario{

        public Usuario(string nome, DateTime dataNascimento, string cadastroPessoaFisica)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            CadastroPessoaFisica = cadastroPessoaFisica;
        }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CadastroPessoaFisica { get; set; }
    }      
}
