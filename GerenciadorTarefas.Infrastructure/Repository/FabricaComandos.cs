using System.Data;
using System.Data.Common;
using GerenciadorTarefas.Domain.Models;
using Microsoft.Data.SqlClient;

namespace GerenciadorTarefas.Insfrastructre.Repository{

    public static class FabricaComandos{

        internal static DbCommand CriaComandoParaCriarUsuario(DbConnection dbConnection, DbTransaction dbTransaction, Usuario usuario)
        {
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Transaction = dbTransaction;
            dbCommand.CommandText = "INSERT USUARIO(NOME, DATANASCIMENTO, CPF) VALUES (@NOME, @DATANASCIMENTO, @CPF)";
            
            AddParametro(dbCommand, "@NOME", ParameterDirection.Input, DbType.String, 55, usuario.Nome);
            AddParametro(dbCommand, "@DATANASCIMENTO",  ParameterDirection.Input, DbType.DateTime, 0, usuario.DataNascimento);
            AddParametro(dbCommand, "@CPF", ParameterDirection.Input, DbType.String, 11, usuario.CadastroPessoaFisica);

            return dbCommand;
        }

        internal static DbCommand CriaComandoParaBuscarUsuario(DbConnection dbConnection, string cadastroPessoaFisica)
        {
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "SELECT * FROM USUARIO WHERE CPF = @CPF";
            
            AddParametro(dbCommand, "@CPF", ParameterDirection.Input, DbType.String, 11, cadastroPessoaFisica);

            return dbCommand;
        
        }
        internal static DbCommand CriaComandoParaAtualizarUsuario(DbConnection dbConnection, DbTransaction dbTransaction, Usuario usuario)
        {
            var dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Transaction = dbTransaction;
            dbCommand.CommandText = "UPDATE USUARIO SET NOME = @NOME, DATANASCIMENTO = @DATANASCIMENTO WHERE CPF = @CPF";
            
            AddParametro(dbCommand, "@CPF", ParameterDirection.Input, DbType.String, 11, usuario.CadastroPessoaFisica);
            AddParametro(dbCommand, "@NOME", ParameterDirection.Input, DbType.String, 55, usuario.Nome);
            AddParametro(dbCommand, "@DATANASCIMENTO", ParameterDirection.Input, DbType.DateTime, 0, usuario.DataNascimento);

            return dbCommand;
        }



        private static void AddParametro(DbCommand dbCommand, string propriedade, ParameterDirection parameterDirection, DbType tipo, int tamanho, object valor)
        {
            var param  = dbCommand.CreateParameter();
            param.ParameterName = propriedade;
            param.Direction = parameterDirection;
            param.DbType = tipo;
            param.Size = tamanho;
            param.Value = valor;
            dbCommand.Parameters.Add(param);
        }
    }
}