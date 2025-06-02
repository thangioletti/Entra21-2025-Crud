using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.Entity;
using MeuPrimeiroCrud.Infrastructure;
using MeuPrimeiroCrud.Repository;
using MySql.Data.MySqlClient;

namespace MeuPrimeiroCrud
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Cadastro de mecanico");
                Console.WriteLine("C - CREATE");
                Console.WriteLine("R - READ");
                Console.WriteLine("U - UPDATE");
                Console.WriteLine("D - DELETE");
                char op = Console.ReadLine().ToUpper()[0];

                switch (op)
                {
                    case 'C':
                        break;
                    case 'R':
                        await Read();
                        break;
                    case 'U':
                        break;
                    case 'D':
                        break;
                }


                Console.WriteLine("Precione enter para continuar");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static async Task Read()
        {
            IMecanicoRepository mecanicoRepository = new MecanicoRepository();
            IEnumerable<MecanicoEntity> mecanicList = await mecanicoRepository.GetAll();
            foreach (MecanicoEntity mecanic in mecanicList)
            {
                Console.WriteLine($"Id {mecanic.Id}");
                Console.WriteLine($"Nome {mecanic.Nome}");
            }

        }
    }
}