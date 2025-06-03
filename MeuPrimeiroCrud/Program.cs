using Dapper;
using MeuPrimeiroCrud.Contracts.Repository;
using MeuPrimeiroCrud.DTO;
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
                        await Create();
                        break;
                    case 'R':
                        await Read();
                        break;
                    case 'U':
                        await Update();
                        break;
                    case 'D':
                        await Delete();
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
                Console.Write($"Id {mecanic.Id}");
                Console.WriteLine($" - Nome {mecanic.Nome}");
            }

        }

        static async Task Create()
        {
            MecanicoInsertDTO mecanico = new MecanicoInsertDTO();

            Console.WriteLine("Digite o nome");
            mecanico.Nome = Console.ReadLine();

            IMecanicoRepository mecanicoRepository = new MecanicoRepository();
            await mecanicoRepository.Insert(mecanico);
            Console.WriteLine("Mecanico cadastrado com sucesso!");

        }

        static async Task Delete()
        {
            await Read();
            Console.WriteLine("Digite o Id que deseja excluir");
            int id = int.Parse(Console.ReadLine());
            IMecanicoRepository mecanicoRepository = new MecanicoRepository();
            await mecanicoRepository.Delete(id);
            Console.WriteLine("Mecanico deletado com sucesso!");
        }

        static async Task Update()
        {
            //Leitura dos dados - Imagine a tabela
            await Read();

            //Seleciona o ID - Simular o clique no botao de editar
            Console.WriteLine("Digite o Id que deseja alterar");
            int id = int.Parse(Console.ReadLine());

            //Carregar o formulário preenchido
            IMecanicoRepository mecanicoRepository = new MecanicoRepository();
            MecanicoEntity mecanico = await mecanicoRepository.GetById(id);

            //Trocar os valores no formulario
            Console.WriteLine($"Digite um novo nome para {mecanico.Nome} ou aperte enter para deixar assim");
            string newName = Console.ReadLine();
            if (newName != string.Empty)
            {
                mecanico.Nome = newName;
            }

            //Chamar o banco
            await mecanicoRepository.Update(mecanico);

            Console.WriteLine("Mecanico alterado com sucesso!");


        }
    }
}