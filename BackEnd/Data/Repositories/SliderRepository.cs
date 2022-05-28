using BackEnd.Data.Configurations;
using BackEnd.Models;
using MongoDB.Driver;

namespace BackEnd.Data.Repositories
{
    public class SlidersRepository : ISliderRepository
    {
        private readonly IMongoCollection<Slider> _sliders;

        public SlidersRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _sliders = database.GetCollection<Slider>("Sliders");
        }

        public async Task<IEnumerable<Slider>> Buscar()
        {
            return await _sliders.FindAsync(slide => true).Result.ToListAsync();
        }
    }
}