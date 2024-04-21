using Dapper;
using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using GerenciamentoEmprestimoLivros.Core.Response;
using GerenciamentoEmprestimoLivros.Infra.Database;
using System.Data;

namespace GerenciamentoEmprestimoLivros.Infra.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly IDbConnection _database;
        public LivroRepository()
        {
            _database = Connection.Database;
        }
        public async Task<ResponseOperation<Livro>> GetAll()
        {
            ResponseOperation<Livro> responseOperation;
            try
            {
                string sql = "SELECT * FROM livro";
                var livros = await _database.QueryAsync<Livro>(sql);

                responseOperation = new()
                {
                    IsSuccess = true,
                    ManyResult = livros.ToList()
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
        public async Task<ResponseOperation<Livro>> GetById(int id)
        {
            ResponseOperation<Livro> responseOperation;
            try
            {
                string sql = "SELECT * FROM livro WHERE id = @Id";

                var livro = await _database.QueryFirstAsync<Livro>(sql, new { Id = id });

                responseOperation = new()
                {
                    IsSuccess = true,
                    SingleResult = livro
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
        public async Task<ResponseOperation<Livro>> Create(Livro livro)
        {
            ResponseOperation<Livro> responseOperation;
            try
            {
                string sql = @"INSERT INTO livro (urlImage,titulo,descricao,autor,status,dataLancamento)
                               VALUES (@UrlImage,@Titulo,@Descricao,@Autor,@Status,@DataLancamento)";

                var parametros = new { livro.UrlImage, livro.Titulo, livro.Descricao, livro.Autor, livro.Status, livro.DataLancamento };

                await _database.ExecuteAsync(sql, parametros);

                responseOperation = new()
                {
                    IsSuccess = true
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
        public async Task<ResponseOperation<Livro>> Update(Livro livro)
        {
            ResponseOperation<Livro> responseOperation;
            try
            {
                string sql = @"UPDATE livro SET urlImage = @UrlImage,titulo = @Titulo,descricao = @Descricao
                              autor = @Autor, status = @Status,dataLancamento = @DataLancamento
                              WHERE id = @Id";

                var parametros = new { livro.UrlImage, livro.Titulo, livro.Descricao, livro.Autor, livro.Status, livro.DataLancamento };

                await _database.ExecuteAsync(sql, parametros);

                responseOperation = new()
                {
                    IsSuccess = true
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
        public async Task<ResponseOperation<Livro>> Delete(int id)
        {
            ResponseOperation<Livro> responseOperation;
            try
            {
                string sql = "DELETE FROM livro WHERE id = @Id";

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
