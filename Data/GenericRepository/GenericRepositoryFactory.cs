using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAppData.GenericRepository
{
    public interface IGenericRepositoryFactory
    {
        IGenericRepository<T> Create<T>(string collectionName) where T : class;
    }

    public class GenericRepositoryFactory : IGenericRepositoryFactory
    {
        private readonly IMongoDatabase _database;

        public GenericRepositoryFactory(IMongoDatabase database)
        {
            _database = database;
        }

        public IGenericRepository<T> Create<T>(string collectionName) where T : class
        {
            return new GenericRepository<T>(_database, collectionName);
        }
    }

}
