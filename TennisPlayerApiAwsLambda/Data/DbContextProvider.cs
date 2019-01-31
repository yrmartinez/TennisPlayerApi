using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace TennisPlayerApiAwsLambda.Data
{
    public class DbContextProvider<TType> 
    {
        private readonly IMongoDatabase _database;

        public DbContextProvider(IConfiguration configuration)
        {
            MongoClient client = new MongoClient(configuration["ConnectionString"]);
            _database = client.GetDatabase(configuration["Database"]);
        }

        public string A => typeof(TType).Name;
        public IMongoCollection<TType> TypeCollection => _database.GetCollection<TType>(typeof(TType).Name);
    }
}
