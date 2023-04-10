using System.Data.Common;
using GerenciadorTarefas.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using GerenciadorTarefas.Domain.Gateways;

namespace GerenciadorTarefas.Insfrastructre.Repository{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string? _connectionString;
        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CriarUsuario(Usuario usuario)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
            DbCommand? dbCommand = null;
            DbTransaction? dbTransaction = null;

            try
            {
                await dbConnection.OpenAsync();
                dbTransaction = await dbConnection.BeginTransactionAsync();

                dbCommand = FabricaComandos.CriaComandoParaCriarUsuario(dbConnection, dbTransaction, usuario);
                dbCommand.ExecuteNonQuery();

                await dbTransaction.CommitAsync();
            }
            catch(Exception ex)
            {
                dbTransaction?.Rollback();
                throw ex;
            }
            finally
            {
                dbCommand?.Dispose();
                dbTransaction?.DisposeAsync();
                await dbConnection.DisposeAsync();
                
            }
        }

        public async Task<Usuario?> BuscarUsuario(string cadastroPessoaFisica)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
            DbCommand? dbCommand = null;

            try
            {
                await dbConnection.OpenAsync();

                dbCommand = FabricaComandos.CriaComandoParaBuscarUsuario(dbConnection, cadastroPessoaFisica);
                DbDataReader dbDataReader = await dbCommand.ExecuteReaderAsync();
                return await MapearParaUsuario(dbDataReader);

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbCommand?.Dispose();
                await dbConnection.DisposeAsync();
                
            }
        }

        private async Task<Usuario?> MapearParaUsuario(DbDataReader dbDataReader){
            if(await dbDataReader.ReadAsync())
            {
                return new Usuario(
                    (string)dbDataReader["NOME"],
                    (DateTime)dbDataReader["DATANASCIMENTO"],
                    (string)dbDataReader["CPF"]
                    );
            }
            return null;
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            DbConnection dbConnection = new SqlConnection(_connectionString);
            DbCommand dbCommand = null;
            DbTransaction dbTransaction = null;

            try
            {
                await dbConnection.OpenAsync();
                dbTransaction = await dbConnection.BeginTransactionAsync();

                dbCommand = FabricaComandos.CriaComandoParaAtualizarUsuario(dbConnection, dbTransaction, usuario);
                await dbCommand.ExecuteNonQueryAsync();

                await dbTransaction.CommitAsync();


            }
            catch(Exception ex)
            {
                await dbTransaction?.RollbackAsync();
                throw ex;
            }
            finally
            {
                dbCommand?.Dispose();
                dbTransaction?.Dispose();
                await dbConnection.DisposeAsync();
            }

        }
    }
}