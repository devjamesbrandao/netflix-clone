using BackEnd.Models;

namespace BackEnd.Data.Repositories
{
    public interface IMidiaRepository
    {
        Task<IEnumerable<Midia>> Buscar();

        Task<Midia> Buscar(string id);
    }
}