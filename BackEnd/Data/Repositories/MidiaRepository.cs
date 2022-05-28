using BackEnd.Data.Configurations;
using BackEnd.Models;
using MongoDB.Driver;

namespace BackEnd.Data.Repositories
{
    public class MidiaRepository : IMidiaRepository
    {
        private readonly IMongoCollection<Midia> _midias;

        public MidiaRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _midias = database.GetCollection<Midia>("Midias");
        }

        public async Task<IEnumerable<Midia>> Buscar()
        {
            return await _midias.FindAsync(slide => true).Result.ToListAsync();
        }

        public async Task<Midia> Buscar(string id)
        {
            return await _midias.FindAsync(Midia => Midia.Id == id).Result.FirstOrDefaultAsync();
        }
    }
}