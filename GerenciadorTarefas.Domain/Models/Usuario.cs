namespace GerenciadorTarefas.Domain.Models {
    public class Usuario{


        public Usuario(string nome, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Tarefas = new List<Tarefa>();
        }
        public Usuario()
        {
            Tarefas = new List<Tarefa>();
        }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Cpf { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }      
}
