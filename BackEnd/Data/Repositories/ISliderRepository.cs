using BackEnd.Models;

namespace BackEnd.Data.Repositories
{
    public interface ISliderRepository
    {
        Task<IEnumerable<Slider>> Buscar();
    }
}