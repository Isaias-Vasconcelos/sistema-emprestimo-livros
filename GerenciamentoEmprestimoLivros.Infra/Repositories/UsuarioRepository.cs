using Dapper;
using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using GerenciamentoEmprestimoLivros.Core.Response;
using GerenciamentoEmprestimoLivros.Infra.Database;
using System.Data;

namespace GerenciamentoEmprestimoLivros.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection _database;
        public UsuarioRepository()
        {
            _database = Connection.Database;
        }
        public async Task<ResponseOperation<Usuario>> GetAll()
        {
            ResponseOperation<Usuario> responseOperation;
            try
            {
                var usuarios = await _database.QueryAsync<Usuario>("SELECT * FROM usuario");

                responseOperation = new()
                {
                    IsSuccess = true,
                    ManyResult = usuarios.ToList()
                };
            }
            catch (Exception ex)
            {
                responseOperation = new()
                {
                    IsSuccess = false,
                    Exception = ex.Message
                };

            }
            return responseOperation;
        }

        public async Task<ResponseOperation<Usuario>> GetById(int id)
        {
            ResponseOperation<Usuario> responseOperation;
            try
            {
                string sql = @"SELECT * FROM usuario WHERE id = @Id";

                var usuario = await _database.QueryFirstAsync<Usuario>(sql, new { Id = id });

                responseOperation = new()
                {
                    IsSuccess = true,
                    SingleResult = usuario ?? new Usuario(0, "not found", "not found")
                };

            }
            catch (Exception ex)
            {
                responseOperation = new()
                {
                    IsSuccess = false,
                    Exception = ex.Message
                };
            }
            return responseOperation;
        }

        public async Task<ResponseOperation<Usuario>> Save(Usuario usuario)
        {
            ResponseOperation<Usuario> responseOperation;
            try
            {
                string sql = "INSERT INTO usuario (nome,email,senha) VALUES (@Nome,@Email,@Senha)";

                var parametros = new { usuario.Nome, usuario.Email, usuario.Senha };

                await _database.ExecuteAsync(sql, parametros);

                responseOperation = new()
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                responseOperation = new()
                {
                    IsSuccess = false,
                    Exception = ex.Message
                };
            }
            return responseOperation;
        }

        public async Task<ResponseOperation<Usuario>> Update(Usuario usuario)
        {
            ResponseOperation<Usuario> responseOperation;
            try
            {
                string sql = "UPDATE usuario SET nome = @Nome, email = @Email, senha = @Senha WHERE id = @Id";

                var parametros = new { usuario.Id, usuario.Nome, usuario.Email, usuario.Senha };

                await _database.ExecuteAsync(sql, parametros);

                responseOperation = new()
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                responseOperation = new()
                {
                    IsSuccess = false,
                    Exception = ex.Message
                };
            }
            return responseOperation;
        }

        public async Task<ResponseOperation<Usuario>> Delete(int id)
        {
            ResponseOperation<Usuario> responseOperation;
            try
            {
                string sql = "DELETE FROM usuario WHERE id = @Id";

                await _database.ExecuteAsync(sql, new { Id = id });

                responseOperation = new()
                {
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                responseOperation = new()
                {
                    IsSuccess = false,
                    Exception = ex.Message
                };
            }
            return responseOperation;
        }
    }
}
