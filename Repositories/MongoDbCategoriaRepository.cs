using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using home_finance_categories.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace home_finance_categories.Repositories
{
    public class MongoDbCategoriaRepository : ICategoriaRepository
    {
        private const string databaseName = "categoria";
        private const string collectionName = "categorias";

        private readonly IMongoCollection<Categoria> categoriaCollection;
        private readonly FilterDefinitionBuilder<Categoria> filterBuilder = Builders<Categoria>.Filter;

        public MongoDbCategoriaRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            categoriaCollection = database.GetCollection<Categoria>(collectionName);
        }

        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            await categoriaCollection.InsertOneAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(Guid id)
        {
            var filter = filterBuilder.Eq(categoria => categoria.Id, id);
            await categoriaCollection.DeleteOneAsync(filter);
        }

        public async Task<Categoria> GetCategoriaAsync(Guid id)
        {
            var filter = filterBuilder.Eq(categoria => categoria.Id, id);
            return await categoriaCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await categoriaCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            var filter = filterBuilder.Eq(existingCategoria => existingCategoria.Id, categoria.Id);
            await categoriaCollection.ReplaceOneAsync(filter, categoria);
        }
    }
}