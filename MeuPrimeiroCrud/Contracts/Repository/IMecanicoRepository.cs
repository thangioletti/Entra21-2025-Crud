using MeuPrimeiroCrud.Entity;

namespace MeuPrimeiroCrud.Contracts.Repository
{
    public interface IMecanicoRepository
    {
        Task<IEnumerable<MecanicoEntity>> GetAll();
    }
}
