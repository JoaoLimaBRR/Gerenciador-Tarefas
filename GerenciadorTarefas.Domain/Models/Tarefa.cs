using System;

namespace GerenciadorTarefas.Domain.Models {
    public class Tarefa{
        public Guid IdTarefa { get; set; }
        public string? Descricao { get; set; }
        public string? Titulo { get; set; }
        public Situacao? Situacao { get; set; }
    }
}