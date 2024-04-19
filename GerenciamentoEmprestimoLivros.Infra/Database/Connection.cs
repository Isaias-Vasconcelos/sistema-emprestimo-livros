using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using OTTQ;
using GerenciamentoEmprestimoLivros.Infra.Database.Tables;

namespace GerenciamentoEmprestimoLivros.Infra.Database
{
    public static class Connection
    {
        public static IDbConnection Database { get; private set; } = new MySqlConnection("Server=localhost;Port=3306;Uid=root;Pwd=jjkeys61;");

        public static void CreateTables()
        {
            Database.Execute(TQ<Usuario>.SqlCreateTable(new Usuario { }));
        }

        public static void CloseConnection()
        {
            Database.Close();
        }
    }
}
