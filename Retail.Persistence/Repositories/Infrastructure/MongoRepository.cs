﻿using MongoDB.Driver;
using Retail.Common;
using Retail.Common.Entities;
using Retail.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Threading.Tasks;
using Unity;

namespace Retail.Persistence.Repositories
{
    public class MongoRepository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected IMongoCollection<TEntity> Entities;

        [Dependency]
        public IMongoDBConfig MongoDatabaseSettings
        {
            set
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(value.ConnectionString));
                settings.SslSettings =
                    new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                var client = new MongoClient(settings);
                var database = client.GetDatabase(value.Database);
                Entities = database.GetCollection<TEntity>(CollectionName);
            }
        }

        private string CollectionName
        {
            get{ return GetType().Name.Replace("Repository", ""); }
        }

        public async Task Remove(TEntity entity) {
            await Entities.DeleteOneAsync(e => e.Id == entity.Id);
        }

        public async Task Remove(string id) {
            await Entities.DeleteOneAsync(e => e.Id == id);
        }

        public async Task Add(TEntity entity)
        {
            await Entities.InsertOneAsync(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                await Add(entity);
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return (await Entities.FindAsync(predicate)).ToList();
        }

        public async Task<TEntity> FindFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return (await Entities.FindAsync(predicate)).FirstOrDefault();
        }
        public virtual async Task<TEntity> Get(string id)
        {
            return (await Entities.FindAsync(e => e.Id == id)).FirstOrDefault();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var answer = await Entities.FindAsync(e => true);
            return answer.ToList();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                await Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            await Entities.ReplaceOneAsync(e => e.Id == entity.Id, entity);
        }

        public async Task<bool> Exists(string id)
        {
            var answer = await Entities.FindAsync(e => e.Id == id);
            return answer.FirstOrDefault() != null;
        }
    }
}
