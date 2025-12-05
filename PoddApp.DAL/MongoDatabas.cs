using MongoDB.Driver;
using PoddApp.Models;

namespace PoddApp.DAL
{
    public class MongoDatabas
    {
        private readonly IMongoClient _client;

        private readonly IMongoDatabase _database;

        private const string ConnectionString = "mongodb+srv://PoddAdmin:PoddAdminLogin@orumongodb.213vyyw.mongodb.net/?appName=OruMongoDB";

        private const string DatabaseName = "OruMongoDB";




        public MongoDatabas()
        {
        
            _client = new MongoClient(ConnectionString);

            _database = _client.GetDatabase(DatabaseName);

        }

        public IMongoClient Client => _client;

        public IMongoCollection<Poddflode> Poddfloden => _database.GetCollection<Poddflode>("PoddFloden");

        public IMongoCollection<Avsnitt> Avsnitt => _database.GetCollection<Avsnitt>("Avsnitt");

        public IMongoCollection<Kategori> Kategorier => _database.GetCollection<Kategori>("Kategorier");

    }
}
