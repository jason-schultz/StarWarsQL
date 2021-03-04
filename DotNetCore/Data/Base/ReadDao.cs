using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StartWarsQL.DotNetCore.Data.Interfaces;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Data.Base
{
    // public class ReadDao<T> : BaseDao<T>, IBaseDaoRead<T, string> where T : BaseEntity
    // {
    //     public ReadDao(IMongoDbSettings settings) : base (settings) { }

    //     public IEnumerable<T> RetrieveAll()
    //     {
    //         return _collection.Find(item => true).ToList();
    //     }

    //     public IEnumerable<T> RetrieveAll(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null)
    //     {
    //         var results = _collection.AsQueryable().Where(condition).ToList();

    //         if(orderByDescending != null && orderByDescending.Value == true)
    //             results.OrderByDescending(x => x.Id);
            
    //         if(maxResult.HasValue && maxResult.Value > 0)
    //             return results.Take(maxResult.Value);

    //         return results;
    //     }

    //     public Task<List<T>> RetrieveAllAsync()
    //     {
    //         return _collection.Find(item => true).ToListAsync();
    //     }

    //     public Task<List<T>> RetrieveAllAsync(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public T RetrieveById(string id)
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public Task<T> RetrieveByIdAsync(string id)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}