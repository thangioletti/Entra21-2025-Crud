using MeuPrimeiroCrud.DTO;
using MeuPrimeiroCrud.Entity;

namespace MeuPrimeiroCrud.Contracts.Repository
{
    public interface IMecanicoRepository
    {
        Task<IEnumerable<MecanicoEntity>> GetAll();

        Task<MecanicoEntity> GetById(int id);

        Task Insert(MecanicoInsertDTO mecanico);

        Task Delete(int id);

        Task Update(MecanicoEntity mecanico);
    }
}
