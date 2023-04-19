namespace GerenciadorTarefas.Insfrastructre.DataProviders.Interface{
    public interface ITokenService{
        string GeneratorToken(string cpfUsuario);
    }
}