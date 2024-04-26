using Dapper;
using GerenciamentoEmprestimoLivros.Core.Entities;
using GerenciamentoEmprestimoLivros.Core.Enums;
using GerenciamentoEmprestimoLivros.Core.Repositories;
using GerenciamentoEmprestimoLivros.Core.Response;
using GerenciamentoEmprestimoLivros.Infra.Database;
using System.Data;

namespace GerenciamentoEmprestimoLivros.Infra.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly IDbConnection _database;
        public EmprestimoRepository()
        {
            _database = Connection.Database;
        }
        public async Task<ResponseOperation<Emprestimo>> GetAll()
        {
            ResponseOperation<Emprestimo> responseOperation;
            try
            {
                string sql = "SELECT * FROM emprestimo";
                var emprestimos = await _database.QueryAsync<Emprestimo>(sql);

                responseOperation = new()
                {
                    IsSuccess = true,
                    ManyResult = emprestimos.ToList()
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
        public async Task<ResponseOperation<Emprestimo>> GetEmprestimosResponsible(string responsible)
        {
            ResponseOperation<Emprestimo> responseOperation;
            try
            {
                string sql = "SELECT * FROM emprestimo WHERE responsavel LIKE @Term";

                var emprestimos = await _database.QueryAsync<Emprestimo>(sql, new { Term = $"%{responsible}%" });

                responseOperation = new()
                {
                    IsSuccess = true,
                    ManyResult = emprestimos.ToList()
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
        public async Task<ResponseOperation<Emprestimo>> GetEmprestimo(int livroId)
        {
            ResponseOperation<Emprestimo> responseOperation;
            try
            {
                string sql = "SELECT * FROM emprestimo WHERE livroId = @Id";

                var emprestimo = await _database.QueryFirstAsync<Emprestimo>(sql, new { Id = livroId });

                responseOperation = new()
                {
                    IsSuccess = true,
                    SingleResult = emprestimo
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
        public async Task<ResponseOperation<Emprestimo>> Create(Emprestimo emprestimo)
        {
            ResponseOperation<Emprestimo> responseOperation;
            try
            {
                string sqlInsert = @"INSERT INTO emprestimo (livroid,responsavel,telefone,emprestadoem,prazoentrega)
                                     VALUES (@LivroId,@Responsavel,@Telefone,@EmprestadoEm,@PrazoEntrega)";

                string sqlUpdate = "UPDATE livro SET status = @Status WHERE id = @LivroId";

                await _database.ExecuteAsync(sqlUpdate, new
                {
                    emprestimo.LivroId,
                    Status = nameof(StatusLivro.INDISPONIVEL)
                });

                await _database.ExecuteAsync(sqlInsert, new
                {
                    emprestimo.LivroId,
                    emprestimo.Responsavel,
                    emprestimo.Telefone,
                    emprestimo.EmprestadoEm,
                    emprestimo.PrazoEntrega
                });

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
        public async Task<ResponseOperation<Emprestimo>> Delete(int id)
        {
            ResponseOperation<Emprestimo> responseOperation;
            try
            {
                var sqlLivroId = "SELECT livroId FROM emprestimo WHERE id = @Id";
                var livroId = await _database.QueryFirstAsync<int>(sqlLivroId, new { Id = id });

                var sqlUpdateLivro = "UPDATE livro SET status = @Status WHERE id = @LivroId";

                await _database.ExecuteAsync(sqlUpdateLivro, new
                {
                    LivroId = livroId,
                    Status = nameof(StatusLivro.DISPONIVEL)
                });

                await _database.ExecuteAsync("DELETE FROM emprestimo WHERE id = @Id", new
                {
                    Id = id,
                });

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
