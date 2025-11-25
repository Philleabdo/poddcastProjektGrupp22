using MongoDB.Driver;
using PoddApp.Models;

namespace PoddApp.DAL
{
    public class MongoDatabas
    {
        private readonly IMongoDatabase _database;

        private const string ConnectionString = "mongodb+srv://philipabdo6:<db_password>@orumongodb.213vyyw.mongodb.net/?appName=OruMongoDB";

        private const string DatabaseName = "OruMongoDB";




        public MongoDatabas()
        {
        
            var client = new MongoClient(ConnectionString);

            _database = client.GetDatabase(DatabaseName);

        }

       

        public IMongoCollection<Poddflode> Poddfloden => _database.GetCollection<Poddflode>("PoddFloden");

        public IMongoCollection<Avsnitt> Avsnitt => _database.GetCollection<Avsnitt>("Avsnitt");

    }
}
