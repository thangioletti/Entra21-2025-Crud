using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.Infrastructure;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud.Repository
{
    public class MecanicoRepository : IMecanicoRepository
    {
        public async Task<IEnumerable<MecanicoEntity>> GetAll()
        {
            Connection connection = new Connection();

            using (MySqlConnection con = connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(MecanicoEntity.Id)},
                            NOME AS {nameof(MecanicoEntity.Nome)}
                        FROM MECANICO
                ";

                IEnumerable<MecanicoEntity> mecanicList = await con.QueryAsync<MecanicoEntity>(sql);
                return mecanicList;                   
            }            
        }
    }
}
