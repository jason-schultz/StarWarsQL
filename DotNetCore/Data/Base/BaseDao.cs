using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Data.Base
{
    public abstract class BaseDao<T> : IBaseDao<T, string> where T : BaseEntity
    {

        protected readonly IMongoDatabase _database;
        protected readonly string _collectionName = typeof(T).Name;
        protected readonly IMongoCollection<T> _collection;

        public BaseDao(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            _database = client.GetDatabase(settings.DatabaseName);
            _collection = _database.GetCollection<T>(_collectionName);
        }

        public void Delete(T item)
        {
            _collection.DeleteOne(item.Id);
        }

        public void DeleteMany(FilterDefinition<T> filter)
        {
            _collection.DeleteMany(filter);
        }

        public T Insert(T item)
        {
            _collection.InsertOne(item);

            return item;   
        }
        public IEnumerable<T> RetrieveAll()
        {
            return _collection.Find(item => true).ToList();
        }

        public IEnumerable<T> RetrieveAll(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null)
        {
            var results = _collection.AsQueryable().Where(condition).ToList();

            if(orderByDescending != null && orderByDescending.Value == true)
                results.OrderByDescending(x => x.Id);
            
            if(maxResult.HasValue && maxResult.Value > 0)
                return results.Take(maxResult.Value);

            return results;
        }

        public Task<List<T>> RetrieveAllAsync()
        {
            return _collection.Find(item => true).ToListAsync();
        }

        public Task<List<T>> RetrieveAllAsync(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null)
        {
            throw new NotImplementedException();
        }

        public T RetrieveById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> RetrieveByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public UpdateDefinition<T> Update(FilterDefinition<T> filter, UpdateDefinition<T> item, UpdateOptions options = null)
        {
            UpdateResult result;

            result = _collection.UpdateOne(filter, item, options);
            
            return item;
        }

        public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> items, UpdateOptions options = null)
        {
            UpdateResult result;
            
            result = _collection.UpdateMany(filter, update: items, options);

            return result;
        }
    }
}
