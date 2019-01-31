
using System.Collections.Generic;
using MongoDB.Driver;
using TennisPlayerApiAwsLambda.Data;
using TennisPlayerApiAwsLambda.Services.Interfaces;

namespace TennisPlayerApiAwsLambda.Services
{
    public class CrudBaseService<TType> : ICrudBaseService<TType> where TType: MongoDocument
    {
        private readonly DbContextProvider<TType> _dbContextProvider;

        public CrudBaseService(DbContextProvider<TType> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public IEnumerable<TType> Get()
        {
            return _dbContextProvider.TypeCollection.Find(x => true).ToList();
        }

        public TType Get(string id)
        {
            return _dbContextProvider.TypeCollection.Find(x => x.Id == id).FirstOrDefault();
        }

        public TType Create(TType input)
        {
            _dbContextProvider.TypeCollection.InsertOne(input);
            return input;
        }

        public void Update(string id, TType input)
        {
            _dbContextProvider.TypeCollection.ReplaceOne(x => x.Id == id, input);
        }

        public void Remove(TType input)
        {
            _dbContextProvider.TypeCollection.DeleteOne(x => x.Id == input.Id);
        }

        public void Remove(string id)
        {
            _dbContextProvider.TypeCollection.DeleteOne(x => x.Id == id);
        }
    }
}
