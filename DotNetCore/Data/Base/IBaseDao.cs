using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using StartWarsQL.DotNetCore.Entities;

namespace StartWarsQL.DotNetCore.Data.Base
{
    public interface IBaseDao<T, ID> where T : BaseEntity
    {
        void Delete(T item);
        void DeleteMany(FilterDefinition<T> filter);
        T Insert(T item);
        IEnumerable<T> RetrieveAll();
        IEnumerable<T> RetrieveAll(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null);
        Task<List<T>> RetrieveAllAsync();
        Task<List<T>> RetrieveAllAsync(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null);
        T RetrieveById(string id);
        Task<T> RetrieveByIdAsync(string id);
        UpdateDefinition<T> Update(FilterDefinition<T> filter, UpdateDefinition<T> item, UpdateOptions options = null);
        UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> items, UpdateOptions options = null);
    }

/*
    public interface IBaseDaoRead<T, ID> where T : BaseEntity 
    { 
        IEnumerable<T> RetrieveAll();
        IEnumerable<T> RetrieveAll(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null);
        Task<List<T>> RetrieveAllAsync();
        Task<List<T>> RetrieveAllAsync(Expression<Func<T, bool>> condition, int? maxResult = null, bool? orderByDescending = null);
        T RetrieveById(string id);
        Task<T> RetrieveByIdAsync(string id);
    }
    public interface IBaseDaoUpdate<T, ID> where T : BaseEntity 
    { 
        UpdateDefinition<T> Update(FilterDefinition<T> filter, UpdateDefinition<T> item, UpdateOptions options = null);
        UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> items, UpdateOptions options = null);
    }
    public interface IBaseDaoInsert<T, ID> where T : BaseEntity 
    {
        T Insert(T item);
     }
    public interface IBaseDaoDelete<T, ID> where T : BaseEntity 
    { 
        void Delete(T item);
        void DeleteMany(FilterDefinition<T> filter);
    }
*/
}